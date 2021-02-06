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
	password: 'root',
	database: 'Sleeping_Elements'
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


// ---- Game ---- //

//---------------Login------------------------
app.post('/players/login', (req, res, next) => {
	console.log(req.body);
	var data = req.body;

	var username = data.Username;
	var password = data.Password;
	


	dbcon.query('SELECT * FROM User WHERE Username=?', [username], function (err, result, fields) {
		//console.log("now here");
		dbcon.on('error', function (err) {
			console.log('[MYSQL ERROR]', err);
		})

		//console.log(result);

		if (result && result.length) {
			if (password == result[0].Password) {
				result[0].Nono = 0;
				res.end(JSON.stringify(result[0]));
			}
			else {//problem 1 wrong pass
				res.json({ "Nono": 1 });
			}
		}
		else {//problem 2 no user with that name   
			res.json({ "Nono": 2 });
		}
	})
});


//-----------------Register-------------------------
app.post('/players/register', (req, res, next) => {
	//console.log(req.body);
	var data = req.body;

	var username = data.username;
	var password = data.password;
	

	dbcon.query('SELECT Username FROM User WHERE Username=?', [username], function (err, result, fields) {
		console.log("now here");
		dbcon.on('error', function (err) {
			console.log('[MYSQL ERROR]', err);
		})

		console.log(result);

		if (result && result.length) {//problem 1 user with that name 

			res.json({ "Problem": 1 });

		}
		else {  

			/*if (password == result[0].Password) {
				result[0].Nono = 0;
				res.end(JSON.stringify(result[0]));
			}
			else {//problem 1 wrong pass
				res.json({ "Nono": 1 });
			}*/

			/*let values = [
			username,
			password
			];*/

			dbcon.query('INSERT INTO User(Username, Password) VALUES (?,?)', [Username, Password], function (err, result, fields) {



				//console.log("now here");
				dbcon.on('error', function (err) {
				console.log('[MYSQL ERROR]', err);

				})

				res.json({ "Problem": 0 });
			})

		}
	})
});

// ---- Companion App ---- // 
/*
//Getting the pet
app.post('/getPet', function(req, res) {

	var userID = req.body

	let sql = "SELECT * FROM Pets WHERE User_ID = "+userID+";"

	dbcon.query(sql, (err, result)=> {

		if (err) throw err;

		res.send(result);
		console.log("Pet Sent: " +result);

	});

});

//Saving the pet

app.post('/sendPetInfo', function (req, res) {

	var name = req.body.name;
	var hp = req.body.hp;
	var hunger = req.body.hunger;
	var hygiene= req.body.hygiene;
	var happy = req.body.happy;
	var userID = req.body.id;


	let sql = "UPDATE Pets SET petName = "+name+", petHealthProgress = "+hp+", petHappinessProgress = "+happy+", petHungerProgress = "+hunger+",  petHygieneProgress = "+hygiene+" WHERE User_ID = "+userID+";"  


});
*/


//Login
app.post('pet/login', function(req, res) {

	console.log("a");
	console.log("[PET LOGIN]", req.body);

	var username = req.body.username;
	var password = req.body.password;

	dbcon.query('SELECT * FROM User WHERE Username=?', [username], function (err, result, fields) {
		//console.log("now here");
		dbcon.on('error', function (err) {
			console.log('[MYSQL ERROR]', err);
		})

		console.log(result);

		if (result && result.length) {
			if (password == result[0].Password) {
				
				res.send("Login Successful");
			}
			else {//problem 1 wrong pass
				res.send("Wrong Password");
			}
		}
		else {//problem 2 no user with that name   
			res.send("Wrong Combination");
		}
	})


});