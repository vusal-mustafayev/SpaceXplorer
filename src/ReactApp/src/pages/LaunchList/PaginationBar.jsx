import { Pagination } from "@mui/material";
const PaginationBar = ({ count, page, handlePageChange }) => (
    <div className="d-flex justify-content-center mt-2 mb-2">
        <Pagination
            className="text-center"
            count={count}
            page={page}
            variant="outlined"
            shape="rounded"
            onChange={handlePageChange}
        />
    </div>
);
export default PaginationBar;