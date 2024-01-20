const About = () => {
    return (
        <div className="container-md d-flex align-items-center justify-content-center vh-75">
            <div>
                <h1 className="text-center display-4 fw-bold mb-5">About SpaceXplorer</h1>

                <p className="lead">
                    SpaceXplorer is a React application that allows you to delve into the fascinating world of rocket launches.
                    Discover detailed information about various rocket launches, including mission details, launch dates, and more.
                    Whether you're a space enthusiast or just curious, SpaceXplorer provides a user-friendly platform to explore the wonders of space exploration.
                </p>

                <hr />

                <p className="lead">Application's source code:
                    <a className="btn btn-light btn-lg ms-2" target="_blank" rel="noreferrer"
                        href="https://github.com/vusal-mustafayev/SpaceXplorer">Source Code</a>
                </p>

                <h6>
                    This is a personal project, with the intention of
                    showing my skills and knowledge of web development.
                </h6>
            </div>
        </div >
    );
};

export default About;