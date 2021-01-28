var express = require('express');
var router = express.Router();

router.get('/list', function(req, res) {
	let sql = `SELECT Username, Password FROM User`;
	dbcon.query(sql, function(err, players, fields) {
	if (err) throw err;
	res.json({players})

	})
});

module.exports = router;