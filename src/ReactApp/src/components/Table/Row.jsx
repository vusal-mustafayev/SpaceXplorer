import Column from "./Column";

const Row = ({ row, prepareRow, formatDate }) => {
    prepareRow(row);
    return (
        <tr {...row.getRowProps()}>
            {row.cells.map((cell, index) => (
                <Column key={index} cell={cell} formatDate={formatDate} />
            ))}   
        </tr>
    );
};

export default Row;