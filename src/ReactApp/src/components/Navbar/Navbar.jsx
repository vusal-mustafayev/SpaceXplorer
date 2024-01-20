import { NavLink } from "react-router-dom";
import "./Navbar.css";

const Navbar = () => {
    return (
        <nav className="navbar navbar-expand-md navbar-dark bg-dark mb-4">            
            <a href="/" className="navbar-brand ms-4">SpaceXplorer</a>          
            <div className="navbar-collapse collapse">
                <ul className="navbar-nav ms-auto">
                    <li className="nav-item">
                        <NavLink to="/" className="nav-link">
                            Launches
                        </NavLink>
                    </li>
                    <li className="nav-item ms-3 me-4">
                        <NavLink to="/about" className="nav-link">
                            About
                        </NavLink>
                    </li>
                </ul>
            </div>
        </nav>
    );
};

export default Navbar;
