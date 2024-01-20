const SearchBar = ({ searchName, onChangeSearchName, findByName }) => (
    <div className="col-md-6">
        <div className="input-group mb-3">
            <input
                type="text"
                className="form-control"
                placeholder="Search by Rocket Name"
                value={searchName}
                onChange={onChangeSearchName}
            />
            <div className="input-group-append">
                <button
                    className="btn btn-outline-secondary"
                    type="button"
                    onClick={findByName}
                >
                    Search
                </button>
            </div>
        </div>
    </div>
);

export default SearchBar;