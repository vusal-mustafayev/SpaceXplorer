import { useMemo, useCallback } from "react";
import { useTable, useSortBy } from "react-table";
import Table from "../../components/Table/Table";

const LaunchTable = ({ launches, openLaunch }) => {

    const openLaunchCallback = useCallback(openLaunch, [openLaunch]);

    const formatDate = (dateString) => {
        const options = { day: "numeric", month: "numeric", year: "numeric" };
        return new Date(dateString).toLocaleDateString("en-GB", options);
    };

    const columns = useMemo(
        () =>
            [
                {
                    Header: "Flight number",
                    accessor: "flightNumber",
                },
                {
                    Header: "Mission Name",
                    accessor: "missionName",
                },
                {
                    Header: "Rocket Name",
                    accessor: "rocket.rocketName",
                },
                {
                    Header: "Rocket Type",
                    accessor: "rocket.rocketType",
                },
                {
                    Header: "Launch Succes",
                    accessor: "launchSuccess",
                    Cell: (props) => {
                        const isSuccessful = props.value;
                        return (
                            <div className="text-center">
                                {isSuccessful ? (
                                    <i className="fas fa-check-circle text-success"></i>
                                ) : (
                                    <i className="fas fa-times-circle text-danger"></i>
                                )}
                            </div>
                        );
                    },
                },
                {
                    Header: "Details",
                    accessor: "details",
                },
                {
                    Header: "Date",
                    accessor: "launchDateUtc",
                    Cell: ({ value }) => formatDate(value),
                },
                {
                    Header: "Actions",
                    accessor: "actions",
                    Cell: (props) => {
                        const rowIdx = props.row.id;
                        return (
                            <div className="text-center">
                                <span onClick={() => openLaunchCallback(rowIdx)}>
                                    <i className="fas fa-info-circle action mr-2"></i>
                                </span>
                            </div>
                        );
                    },
                },
            ],
        [openLaunchCallback]
    );

    const {
        getTableProps,
        getTableBodyProps,
        headerGroups,
        rows,
        prepareRow,
    } = useTable(
        {
            columns,
            data: launches,
            disableSortRemove: true,
        },
        useSortBy
    );
    return (
        <Table
            getTableProps={getTableProps}
            getTableBodyProps={getTableBodyProps}
            headerGroups={headerGroups}
            rows={rows}
            prepareRow={prepareRow}
            formatDate={formatDate}           
        />
    );
};  

export default LaunchTable;