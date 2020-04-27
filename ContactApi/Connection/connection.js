var sql = require("mssql");
var connect = function () {
    var conn = new sql.ConnectionPool({
        user: 'sa',
        password: 'Admin123',
        server: 'yankzsoe',
        database: 'GIC',
        "options": {
            "encrypt": true,
            "enableArithAbort": true
        },
    });
    return conn;
};
module.exports = connect;