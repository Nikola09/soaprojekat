'use strict'

var Express = require('express')
//var entities = require('seneca-entity')
var Web = require('seneca-web')
var amqp = require('amqplib/callback_api');
const seneca = require('seneca')();
seneca.use('entity');

seneca.use('mongo-store', {
  name: 'NodeMicroserviceDB',	
  host: '172.25.124.82',
  port: 27017,
  options: { useUnifiedTopology: true } 
});

//seneca.ready(() => {
//});

amqp.connect('amqp://172.25.124.88', function (error0, connection) { 
    if (error0) {
        throw error0;
    }
    connection.createChannel(function (error1, channel) {
        if (error1) {
            throw error1;
        }
        var exchange5 = 'ex5';
        var exchange6 = 'ex6';
        var exchange7 = 'ex7';
        var exchange8 = 'ex8';
        var queue = 'transfer3';

        channel.assertExchange(exchange5, 'fanout', {
            durable: false
        });
        channel.assertExchange(exchange6, 'fanout', {
            durable: false
        });
        channel.assertExchange(exchange7, 'fanout', {
            durable: false
        });
        channel.assertExchange(exchange8, 'fanout', {
            durable: false
        });
        channel.assertQueue(queue, {
            exclusive: false
        } );
            console.log(" [*] Waiting for messages in %s. To exit press CTRL+C", queue);
            channel.bindQueue(queue, exchange5, '');
			channel.bindQueue(queue, exchange6, '');
			channel.bindQueue(queue, exchange7, '');
			channel.bindQueue(queue, exchange8, '');

            channel.consume(queue, function (msg) {
                if (msg.content) {
					
					var obj= JSON.parse(msg.content.toString());
					console.log(msg.content.toString());
					switch(msg.fields.routingKey.toString())
					{
						case "keybat0":
							if(obj.Level < 16) 
							{
								var entity = seneca.make$('battery')
								entity.storage_id = obj.Id
								entity.timestamp = obj.Timestamp
								entity.level = obj.Level
								entity.temperature = obj.Temperature
								entity.save$((err,entity) => {
									console.log( "Battery saved!" )
								  });
							}
							break;
						
						case "keyapi0":
							if(obj.InVehicle > 80 || obj.onBicycle > 80 || obj.onFoot > 80 || obj.Running > 80 || obj.Walking > 80)
							{
								var entity = seneca.make$('apii')
								entity.storage_id = obj.Id
								entity.timestamp = obj.Timestamp
								entity.still = obj.Still
								entity.onFoot = obj.OnFoot
								entity.walking = obj.Walking
								entity.running = obj.Running
								entity.onBicycle = obj.OnBicycle
								entity.inVehicle = obj.InVehicle
								entity.tilting = obj.Tilting
								entity.unknown = obj.Unknown
								entity.save$((err,entity) => {
									console.log( "Apii saved!" )
								  });
							}
							break;
						
						case "keyloc0":
							if(obj.Accuracy < 20.0)
							{
								var entity = seneca.make$('location')
								entity.storage_id = obj.Id
								entity.timestamp = obj.Timestamp
								entity.accuracy = obj.Accuracy
								entity.latitude = obj.Latitude
								entity.longitude = obj.Longitude
								entity.altitude = obj.Altitude
								entity.save$((err,entity) => {
									console.log( "Location saved!" )
								  });
							}
							break;
						
						case "keyamb0":
							if(obj.Lumix > 10)
							{
								var entity = seneca.make$('ambient')
								entity.storage_id = obj.Id
								entity.timestamp = obj.Timestamp
								entity.lumix = obj.Lumix
								entity.temperature = obj.Temperature
								entity.save$((err,entity) => {
									console.log( "Ambient saved!" )
								  });
							}
							break;
						default: 
							console.log(" [x]RoutingKeyError %s", msg.fields.routingKey.toString());
					}
                }
            }, {
                noAck: true
            });
        });
	});
var Routes = [{
    prefix: '/api',
    pin: 'role:api,cmd:*',
    map: {
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