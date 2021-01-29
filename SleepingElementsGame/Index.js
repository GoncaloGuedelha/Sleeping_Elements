var http = require('http');
var mysql = require('mysql2');
var express = require('express');
var cors = require('cors');
var bodyParser = require('body-parser');


const hostname = '127.0.0.1';
const port = 3000;

dbcon = mysql.createConnection({
	host: 'localhost',
	user: 'root',
	password: 'Macaco01',
	database: 'SleepingElements'
});

dbcon.connect(function(err) {
	if (err) throw err;
	console.log("MySQL Connected!");
});

var app = express();
app.use(cors())
app.use(bodyParser.json());


app.listen(port, hostname, () => console.log(`Server running at 
			http://${hostname}:${port}/`));

app.post('/players/login', (req, res, next) => {
	console.log(req.body);
	var data = req.body;

	var username = data.username;
	var password = data.password;
	

	dbcon.query('SELECT * FROM User WHERE Username=?', [username], function (err, result, fields) {
		console.log("now here");
		dbcon.on('error', function (err) {
			console.log('[MYSQL ERROR]', err);
		})

		console.log(result);

		if (result && result.length) {
			if (password == result[0].Password) {
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
