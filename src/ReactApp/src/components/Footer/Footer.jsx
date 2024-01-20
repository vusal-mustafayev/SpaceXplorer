import "./Footer.css";
const Footer = () => {
    const currentYear = new Date().getFullYear();
    return (
        <footer className="footer fixed-bottom">
            <div className="container">               
                <div className="text-muted text-center">
                    <a className="text-info text-decoration-none me-2"
                        target="_blank" rel="noreferrer"
                        href="https://github.com/vusal-mustafayev/SpaceXplorer/blob/master/LICENSE">
                        Licensed under MIT License</a>
                    <span className="custom-marker me-2"></span>
                    {currentYear}
                </div>
            </div>
        </footer>
    );
};

export default Footer;