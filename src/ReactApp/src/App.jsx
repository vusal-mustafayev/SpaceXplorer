import "bootstrap/dist/css/bootstrap.min.css";
import "@fortawesome/fontawesome-free/css/all.css";
import "@fortawesome/fontawesome-free/js/all.js";
import "./App.css";
import Layout from "./components/Layout/Layout";
import AppRoutes from "./AppRoutes";

const App = () => {
    return (
        <Layout>
            <AppRoutes />
        </Layout>
    );
};

export default App;