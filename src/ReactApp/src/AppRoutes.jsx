import { Routes, Route } from "react-router-dom";
import Launch from "./pages/Launch/Launch";
import LaunchList from "./pages/LaunchList/LaunchList";
import Notfound from "./pages/NotFound";
import About from "./components/About/About";

const AppRoutes = () => {
    return (
        <Routes>
            <Route index exact path="/" element={<LaunchList />} />
            <Route exact path="/launches/:id" element={<Launch />} />
            <Route exact path="*" element={<Notfound />} />
            <Route exact path="/about" element={<About />} />
        </Routes>
    );
};

export default AppRoutes;