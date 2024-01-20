const Column = ({ cell, formatDate }) => (
    <td {...cell.getCellProps()}>{cell.render("Cell", { formatDate })}</td>
);

Column.Cell = ({ children }) => <td>{children}</td>;

export default Column;