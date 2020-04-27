var express = require('express');
var router = express.Router();
var sql = require("mssql");
var conn = require("../Connection/connection")();

var routes = function () {
    router.route('/')
        .get(function (req, res) {
            conn.connect().then(function () {
                var sqlQuery = "SELECT * FROM CONTACT";
                var req = new sql.Request(conn);
                req.query(sqlQuery).then(function (recordset) {
                    res.json(recordset.recordset);
                    conn.close();
                })
                    .catch(function (err) {
                        conn.close();
                        res.status(400).send("Error while get data");
                    });
            })
                .catch(function (err) {
                    conn.close();
                    res.status(400).send("Error while connecting..");
                });
        });

    router.route('/search/:name')
        .get(function (req, res) {
            var name = req.params.name;
            conn.connect().then(function () {
                var sqlQuery = "SELECT * FROM CONTACT WHERE Name like '%" + name + "%' ";
                var req = new sql.Request(conn);
                req.query(sqlQuery).then(function (recordset) {
                    res.json(recordset.recordset);
                    conn.close();
                })
                    .catch(function (err) {
                        conn.close();
                        res.status(400).send("Error while get data");
                    });
            })
                .catch(function (err) {
                    conn.close();
                    res.status(400).send("Error while connecting..");
                });
        });

    router.route('/')
        .post(function (req, res) {
            conn.connect().then(function () {
                var transaction = new sql.Transaction(conn);
                transaction.begin().then(function () {
                    var request = new sql.Request(transaction)
                    request.input("Name", sql.VarChar(50), req.body.Name)
                    request.input("PhoneNumber", sql.VarChar(15), req.body.PhoneNumber)
                    request.input("Address", sql.VarChar(150), req.body.Address)
                    request.execute("USP_InsertContact").then(function () {
                        transaction.commit().then(function (recordSet) {
                            conn.close();
                            res.status(200).send(req.body);
                        }).catch(function (err) {
                            conn.close();
                            res.status(400).send("Error while inserting data");
                        });
                    }).catch(function (err) {
                        conn.close();
                        res.status(400).send("Error while inserting data");
                    });
                }).catch(function (err) {
                    conn.close();
                    res.status(400).send("Error while inserting data");
                });
            }).catch(function (err) {
                conn.close();
                res.status(400).send("Error while inserting data");
            });
        });

    router.route('/:id')
        .put(function (req, res) {
            const id = req.params.id;
            conn.connect().then(function () {
                var transaction = new sql.Transaction(conn);
                transaction.begin().then(function () {
                    var request = new sql.Request(transaction);
                    request.input("Id", sql.Int, id)
                    request.input("Name", sql.VarChar(50), req.body.Name)
                    request.input("PhoneNumber", sql.VarChar(15), req.body.PhoneNumber)
                    request.input("Address", sql.VarChar(150), req.body.Address)
                    request.execute("USP_UpdateContact").then(function () {
                        transaction.commit().then(function (recordSet) {
                            conn.close();
                            res.status(200).send(req.body);
                        }).catch(function (err) {
                            conn.close();
                            res.status(400).send("Error while updating data");
                        });
                    }).catch(function (err) {
                        conn.close();
                        res.status(400).send("Error while updating data");
                    });
                }).catch(function (err) {
                    conn.close();
                    res.status(400).send("Error while updating data");
                });
            }).catch(function (err) {
                conn.close();
                res.status(400).send("Error while updating data");
            });
        });

    router.route('/:id')
        .delete(function (req, res) {
            conn.connect().then(function () {
                var transaction = new sql.Transaction(conn);
                transaction.begin().then(function () {
                    var request = new sql.Request(transaction);
                    request.input("Id", sql.Int, req.params.id)
                    request.execute("USP_DeleteContact").then(function () {
                        transaction.commit().then(function (recordSet) {
                            conn.close();
                            res.status(200).send('OK');
                        }).catch(function (err) {
                            conn.close();
                            res.status(400).send("Error while Deleting data");
                        });
                    }).catch(function (err) {
                        conn.close();
                        res.status(400).send("Error while Deleting data");
                    });
                }).catch(function (err) {
                    conn.close();
                    res.status(400).send("Error while Deleting data");
                });
            })
        });

    return router;
};
module.exports = routes;