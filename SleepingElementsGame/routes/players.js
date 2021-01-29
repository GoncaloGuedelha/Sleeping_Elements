var express = require('express');
var router = express.Router();

router.post('/players/login', (req, res, next) => {

	var loginData = req.body;

	var username = data.username;
	var password = data.password;
	console.log("here");

	dbcon.query('SELECT * FROM User WHERE Username=?', [username], function (err, result, fields) {
		console.log("now here");
		dbcon.on('error', function (err) {
			console.log('[MYSQL ERROR]', err);
		})

		console.log(result);

		if (result && result.length) {
			if (Password == result[0].Password) {
				result[0].Nono = 0;
				res.end(JSON.stringify(result[0]));
			}
			else {//status 1 wrong pass
				res.json({ "Nono": 1 });
			}
		}
		else {//status 2 no user with that name   
			res.json({ "Nono": 2 });
		}
	})
});

module.exports = router;