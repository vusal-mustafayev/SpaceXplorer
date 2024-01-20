import { useState, useEffect } from 'react';
import { useParams } from 'react-router-dom';
import { Link } from "react-router-dom";
import LaunchDataService from "../../services/LaunchService";
import { Grid } from 'react-loader-spinner'
import "./Launch.css";
function Launch() {
    const [launch, setLaunch] = useState(null);
    const { id } = useParams();
    const [error, setError] = useState(null);

    useEffect(() => {
        async function fetchLaunch() {
            try {
                const response = await LaunchDataService.get(id);
                setLaunch(response.data);
            } catch (err) {
                setError(err.response?.data.detail || err.response?.data.title || "Oops! Something went wrong. Please try again later.");
                console.log(err);
            }
        }
        fetchLaunch();
    }, [id]);

    if (error) {
        return (
            <div className="container">
                <p>{error}</p>
            </div>
        );
    }

    if (!launch) {
        return (
            <div className="container-md text-center">
                <Grid
                    visible={true}
                    height="100"
                    width="100"
                    color="#4fa94d"
                    ariaLabel="grid-loading"
                    radius="12.5"                    
                    wrapperStyle={{}}
                    wrapperClass="grid-wrapper"
                />
            </div>
        );
    }

    return (
        <section className="container py-5">
            <div className="row justify-content-around align-items-center">
                <div className="col-md-5">
                    <img src={launch.links.missionPatch} alt="Mission Patch" className="w-100 mb-4" style={{ marginLeft: "-100%" }} />
                </div>
                <div className="col-md-7">
                    <h2 className="display-4 mb-3">{launch.missionName}</h2>
                    <p className="lead font-weight-bold">Flight Number: <span className="lead">{launch.flightNumber}</span></p>
                    <p className="font-weight-bold">Rocket Name: {launch.rocket.rocketName}</p>

                    <div className="mt-3">
                        <p>Rocket Type: {launch.rocket.rocketType}</p>
                        <p>Launch Date: {new Date(launch.launchDateUtc).toLocaleDateString()}</p>
                        <p>
                            Launch Success:{" "}
                            {launch.launchSuccess ? (
                                <i className="fas fa-check-circle text-success"></i>
                            ) : (
                                <i className="fas fa-times-circle text-danger"></i>
                            )}
                        </p>
                        <p>
                            Upcoming:{" "}
                            {launch.upcoming ? (
                                <i className="fas fa-check-circle text-success"></i>
                            ) : (
                                <i className="fas fa-times-circle text-danger"></i>
                            )}
                        </p>
                        <p>Details: {launch.details}</p>
                        {launch.launchFailureDetails && (
                            <p>Failure Reasons: {launch.launchFailureDetails.reason}</p>
                        )}
                    </div>

                    <h3 className="d-flex justify-content-between h3 mt-4">
                        More info:
                        <a href={launch.links.articleLink} target="_blank" rel="noopener noreferrer" className="py-1 text-center text-primary-500 hover-text-primary-700 transition-none user-select-none">
                            <i className="fab fa-readme"></i>
                        </a>
                        <a href={launch.links.wikipedia} target="_blank" rel="noopener noreferrer" className="py-1 text-center text-primary-500 hover-text-primary-700 transition-none user-select-none">
                            <i className="fab fa-wikipedia-w"></i>
                        </a>
                        <a href={launch.links.videoLink} target="_blank" rel="noopener noreferrer" className="py-1 text-center text-primary-500 hover-text-primary-700 transition-none user-select-none">
                            <i className="fab fa-youtube"></i>
                        </a>
                    </h3>
                </div>
            </div>
            <Link
                to="/"
                className="h3 py-1 text-center text-primary-500 hover-text-primary-700 transition-none user-select-none d-block mt-4">
                &larr; Go to Home Page
            </Link>
        </section>
    );
}

export default Launch;