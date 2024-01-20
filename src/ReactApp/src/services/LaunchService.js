import http from "./http-common";

const getAll = (params) => {
    return http.get(`api/launches`, { params });
};

const get = (id) => {
    return http.get(`api/launches/${id}`);
};

const LaunchService = {
    getAll,
    get
};

export default LaunchService;