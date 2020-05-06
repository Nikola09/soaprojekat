'use strict'

var Express = require('express')
//var entities = require('seneca-entity')
var Web = require('seneca-web')
var amqp = require('amqplib/callback_api');
const seneca = require('seneca')();
seneca.use('entity');

seneca.ready(() => {
	var battery = seneca.make("battery")
	battery.storage_id = 123
	battery.timestamp = 321
	battery.level = 10
	battery.temperature = 30
	battery.save$((err,battery) => {
		console.log( "Battery saved!" )
	});
});

var Routes = [{
    prefix: '/api',
    pin: 'role:api,cmd:*',
    map: {
        home: { GET: true },
        fetch: { GET: true},
		batteries: { GET: true},
		battery: { GET: true, suffix:'/:id'},
		batteryadd: {GET:false,POST:true, suffix:'/:id'},
		batteryedit: {GET:false,POST:true, suffix:'/:id'},
		batteryremove: { GET: false, DELETE: true, suffix:'/:id'},
		apiis: { GET: true},
		apii: { GET: true, suffix:'/:id'},
		apiiadd: { GET:false,POST:true, suffix:'/:id'},
		apiiedit: { GET:false,POST:true, suffix:'/:id'},
		apiiremove: {GET: false, DELETE: true, suffix:'/:id'},
		locations: { GET: true},
		location: { GET: true, suffix:'/:id'},
		locationadd: { GET:false,POST:true, suffix:'/:id'},
		locationedit: { GET:false,POST:true, suffix:'/:id'},
		locationremove: { GET: false, DELETE: true, suffix:'/:id'},
		ambients: { GET: true},
		ambient: { GET: true, suffix:'/:id'},
		ambientedit: { GET:false,POST:true, suffix:'/:id'},
		ambientremove: { GET: false, DELETE: true, suffix:'/:id'}
		
    }
}]
var config = {
    routes: Routes,
    adapter: require('seneca-web-adapter-express'),
    context: Express()
}

seneca.client()
    .use(Web, config)
    .ready(() => {
        var server = seneca.export('web/context')()
        server.listen('4000', () => {
            console.log('server started on: 4000')
        })
    })
	
seneca.add({ role: 'api', cmd: 'home'}, function (args, done) {
    done(null, { response: "hey" });
});
seneca.add({ role: 'api', cmd: 'fetch'}, function (args, done) {
	 var apple = this.make("fruit");
	 apple.data$(false);
	console.log('got here');
	 apple.list$({}, done);
});

seneca.add({ role: 'api', cmd: 'batteries'}, function (args, done) {
	 var battery = this.make("battery");
	 battery.list$({}, done);
});
seneca.add({ role: 'api', cmd: 'battery'}, function (args, done) {
	var battery = this.make("battery");
	battery.load$(args.args.params.id,  done);
});
seneca.add({ role: 'api', cmd: 'batteryadd'}, function (args, done) {
	var battery = this.make("battery")
	battery.storage_id = args.args.body.Id
	battery.timestamp = args.args.body.Timestamp
	battery.level = args.args.body.Level
	battery.temperature = args.args.body.Temperature
	battery.save$((err,battery) => {
		console.log( "Battery saved!" )
	});
});
seneca.add({ role: 'api', cmd: 'batteryedit'}, function (args, done) {
	var battery = this.make("battery");
	battery.load$(args.args.params.id,  function(err, result) { 
		result.data$({ storage_id: args.args.body.Id, 
			timestamp: args.args.body.Timestamp, 
			level: args.args.body.Level, 
			temperature: args.args.body.Temperature });
		result.save$();
	});
});
seneca.add({ role: 'api', cmd: 'batteryremove'}, function (args, done) {
	var battery = this.make("battery");
	battery.remove$(args.args.params.id, function (err) { done(err, null); });
});


seneca.add({ role: 'api', cmd: 'apiis'}, function (args, done) {
	 var apii = this.make("apii");
	 apii.list$({}, done);
});
seneca.add({ role: 'api', cmd: 'apii'}, function (args, done) {
	var apii = this.make("apii");
	apii.load$(args.args.params.id,  done);
});
seneca.add({ role: 'api', cmd: 'apiiadd'}, function (args, done) {
	var apii = this.make("apii")
	apii.storage_id = obj.Id
	apii.timestamp = obj.Timestamp
	apii.still = obj.Still
	apii.onFoot = obj.OnFoot
	apii.walking = obj.Walking
	apii.running = obj.Running
	apii.onBicycle = obj.OnBicycle
	apii.inVehicle = obj.InVehicle
	apii.tilting = obj.Tilting
	apii.unknown = obj.Unknown
	apii.save$((err,apii) => {
		console.log( "Apii saved!" )
	});
});
seneca.add({ role: 'api', cmd: 'apiiedit'}, function (args, done) {
	var apii = this.make("apii");
	apii.load$(args.args.params.id,  function(err, result) {
		result.data$({ storage_id: args.args.body.Id, 
			timestamp: args.args.body.Timestamp, 
			still:args.args.body.Still,
			onFoot: args.args.body.OnFoot,
			walking: args.args.body.Walking,
			running: args.args.body.Running,
			onBicycle: args.args.body.OnBicycle,
			inVehicle: args.args.body.InVehicle,
			tilting: args.args.body.Tilting,
			unknown: args.args.body.Unknown });
		result.save$();
	});
});
seneca.add({ role: 'api', cmd: 'apiiremove'}, function (args, done) {
	var apii = this.make("apii");
	apii.remove$(args.args.params.id, function (err) { done(err, null); });
});


seneca.add({ role: 'api', cmd: 'locations'}, function (args, done) {
	 var location_ent = this.make("location");
	 location_ent.list$({}, done);
});
seneca.add({ role: 'api', cmd: 'location'}, function (args, done) {
	var location_ent = this.make("location");
	location_ent.load$(args.args.params.id,  done);
});
seneca.add({ role: 'api', cmd: 'locationadd'}, function (args, done) {
	var location_ent = this.make("location")
	location_ent.storage_id = args.args.body.Id
	location_ent.timestamp = args.args.body.Timestamp
	location_ent.accuracy = args.args.body.Accuracy
	location_ent.latitude = args.args.body.Latitude
	location_ent.longitude = args.args.body.Longitude
	location_ent.altitude = args.args.body.Altitude
	location_ent.save$((err,location_ent) => {
		console.log( "Location saved!" )
	});
});
seneca.add({ role: 'api', cmd: 'locationedit'}, function (args, done) {
	var location_ent = this.make("location");
	location_ent.load$(args.args.params.id,  function(err, result) { 
		result.data$({ storage_id: args.args.body.Id, 
			timestamp: args.args.body.Timestamp, 
			accuracy: args.args.body.Accuracy,
			latitude: args.args.body.Latitude,
			longitude: args.args.body.Longitude,
			altitude: args.args.body.Altitude});
		result.save$();
	});
});
seneca.add({ role: 'api', cmd: 'locationremove'}, function (args, done) {
	var location_ent = this.make("location");
	location_ent.remove$(args.args.params.id, function (err) { done(err, null); });
});


seneca.add({ role: 'api', cmd: 'ambients'}, function (args, done) {
	 var ambient = this.make("ambient");
	 ambient.list$({}, done);
});
seneca.add({ role: 'api', cmd: 'ambient'}, function (args, done) {
	var ambient = this.make("ambient");
	ambient.load$(args.args.params.id,  done);
});
seneca.add({ role: 'api', cmd: 'ambientadd'}, function (args, done) {
	var ambient = this.make("ambient")
	ambient.storage_id = args.args.body.Id
	ambient.timestamp = args.args.bodyt.Timestamp
	ambient.lumix = args.args.body.Lumix
	ambient.temperature = args.args.body.Temperature
	ambient.save$((err,ambient) => {
		console.log( "Ambient saved!" )
	});
});
seneca.add({ role: 'api', cmd: 'ambientedit'}, function (args, done) {
	var ambient = this.make("ambient");
	ambient.load$(args.args.params.id,  function(err, result) {
		result.data$({ storage_id: args.args.body.Id, 
			timestamp: args.args.body.Timestamp, 
			lumix: args.args.body.Lumix,
			temperature: args.args.body.Temperature});
		result.save$();
	});
});
seneca.add({ role: 'api', cmd: 'ambientremove'}, function (args, done) {
	var ambient = this.make("ambient");
	ambient.remove$(args.args.params.id, function (err) { done(err, null); });
});