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

//-------GetGamePet--------//

app.post('/players/pet', (req, res, next) => {
	console.log(req.body);
	var data = req.body;


	var userID = data.user_ID;


	dbcon.query('SELECT petHealthProgress, user_ID FROM Pets WHERE user_ID=?', [userID], function (err, result, fields) {
		console.log("now here");
		dbcon.on('error', function (err) {
			console.log('[MYSQL ERROR]', err);
		})
		console.log(JSON.stringify(result));

		if (result && result.length) {

			result[0].Problem = 0;
			res.end(JSON.stringify(result[0]));

		}

	})
});



// ---- Companion App ---- // 



//Saving the pet

app.post('/sendPetInfo', function (req, res) {

	var name = req.body.Petname;
	var hp = req.body.petHealthProgress;
	var hunger = req.body.petHungerProgress;
	var hygiene= req.body.petHygieneProgress;
	var happy = req.body.petHappinessProgress;
	var petID = req.body.pet_ID;

	console.log("[PET INFO BODY]", req.body);
	

	dbcon.query("UPDATE Pets SET petName = "+name+", petHealthProgress = "+hp+", petHappinessProgress = "+happy+", petHungerProgress = "+hunger+",  petHygieneProgress = "+hygiene+" WHERE pet_ID = "+petID+";", function(err, result) {

		dbcon.on("error", function(err) {
			console.log("[MySQL ERROR]", err);
		})
	
		dbcon.query("SELECT * FROM Pets where pet_ID = "+petID, function(err, result) {

			dbcon.on("error", function(err){
				console.log("[MYSQL ERROR]", err);
			})

			console.log("[PET INFO]", result);

			res.end(JSON.stringify(result[0]));

		})


	})


});


//Login
app.post('/login', function(req, res) {

	console.log("[PET LOGIN]", req.body);

	var username = req.body.Username;
	var password = req.body.Password;


	dbcon.query('SELECT * FROM User WHERE Username=?', [username], function (err, result, fields) {
		
		dbcon.on('error', function (err) {
			console.log('[MYSQL ERROR]', err);
		})

		if (result && result.length) {
			
			if (password == result[0].Password) {
				
					console.log(result);


					console.log("I'm here with", username);
					


					dbcon.query('SELECT User_ID from user WHERE Username=? and Password=?', [username, password] , function(err, result2) {

						dbcon.on('error', function(err) {
							console.log("[MySQL ERROR]", err);
						})

						console.log("[RESULT2]" + JSON.stringify(result2[0]));
						res.end(JSON.stringify(result2[0]));


					})

		
			} else {//problem 1 wrong pass
		
				res.end(JSON.stringify("Wrong Password"));
				
			}
		
		} else {//problem 2 no user with that name   
		
			res.end(JSON.stringify("Wrong Combination"));
		
		}

	})

});

//Getting the pet
app.post('/getPet', function(req, res) {

	console.log(req.body)

	var userID = req.body.User_ID

	let sql = "SELECT * FROM Pets WHERE User_ID = "+userID+";"

	dbcon.query(sql, (err, result)=> {

		dbcon.on('error', function(err){
			console.log("{MYSQL ERROR]", err);
		})

		res.send(JSON.stringify(result[0]));
		console.log("Pet Sent: " +JSON.stringify(result[0])); 

	});

});