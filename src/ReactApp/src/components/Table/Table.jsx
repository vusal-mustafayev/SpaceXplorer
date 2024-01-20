import Row from "./Row";

const Table = ({
    getTableProps,
    getTableBodyProps,
    headerGroups,
    rows,
    prepareRow,
    formatDate,
    openLaunch
}) => (
    <div className="col-md-10 list">
        <table
            className="table table-striped table-bordered"
            {...getTableProps()}
        >
            <thead>
                {headerGroups.map((headerGroup) => (
                    <tr {...headerGroup.getHeaderGroupProps()}>
                        {headerGroup.headers.map((column) => (
                            <th {...column.getHeaderProps(column.getSortByToggleProps())}>
                                {column.render("Header")}
                                <span>
                                    {column.isSorted ? (
                                        column.isSortedDesc ? (
                                            <i className="fas fa-sort-down"></i>
                                        ) : (
                                            <i className="fas fa-sort-up"></i>
                                        )
                                    ) : (
                                        ""
                                    )}
                                </span>
                            </th>
                        ))}
                    </tr>
                ))}
            </thead>

            <tbody {...getTableBodyProps()}>
                {rows.map((row) => (
                    <Row
                        key={row.id}
                        row={row}
                        prepareRow={prepareRow}
                        formatDate={formatDate}                       
                    />
                ))}
            </tbody>
        </table>
    </div>
);

export default Table;