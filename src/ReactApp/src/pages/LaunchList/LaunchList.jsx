import { useNavigate } from "react-router-dom";
import SearchBar from "./SearchBar";
import LaunchTable from "./LaunchTable";
import PaginationBar from "./PaginationBar";
import  { useState, useEffect, useRef } from "react";
import LaunchDataService from "../../services/LaunchService";

const LaunchList = () => {
    const navigate = useNavigate();
    const launchesRef = useRef();

    const [launches, setLaunches] = useState([]);
    const [searchName, setSearchName] = useState("");

    const [page, setPage] = useState(1);
    const [count, setCount] = useState(1);
    const pageSize = 10;
    launchesRef.current = launches;

    const onChangeSearchName = (e) => {
        const searchName = e.target.value;
        setSearchName(searchName);
    };

    const openLaunch = (rowIndex) => {
        const id = launchesRef.current[rowIndex].flightNumber;
        navigate(`launches/${id}`, { state: { id: id } });
    };

    const getRequestParams = (searchName, page, pageSize) => {
        let params = {};

        if (searchName) {
            params["RocketName"] = searchName;
        }

        if (page) {
            params["Offset"] = page;
        }

        if (pageSize) {
            params["Limit"] = pageSize;
        }
        return params;
    };

    const retrieveLaunches = () => {
        const params = getRequestParams(searchName, page, pageSize);

        LaunchDataService.getAll(params)
            .then((response) => {
                const { launches, totalPages } = response.data;

                setLaunches(launches);
                setCount(totalPages);
            })
            .catch((e) => {
                console.error('Error fetching launches:', e);
            });
    };

    useEffect(retrieveLaunches, [searchName, page, pageSize]);

    const findByName = () => {
        setPage(1);
        retrieveLaunches();
    };

    const handlePageChange = (event, value) => {
        setPage(value);
    };

    return (
        <div className="list row justify-content-center">
            <SearchBar
                searchName={searchName}
                onChangeSearchName={onChangeSearchName}
                findByName={findByName}
            />
            <LaunchTable
                launches={launches}
                openLaunch={openLaunch}
            />
            <PaginationBar
                count={count}
                page={page}
                handlePageChange={handlePageChange}
            />
        </div>
    );
};

export default LaunchList;