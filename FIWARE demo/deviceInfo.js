const request = require("request");
const NgsiV2 = require("ngsi_v2");
const defaultClient = NgsiV2.ApiClient.instance;
defaultClient.basePath = process.env.CONTEXT_BROKER || "http://localhost:1026/v2";

const options = {
    method: "GET",
    url: "http://localhost:1026/v2/entities/urn:ngsi-ld:Device:1",
    qs: { options: "keyValues" }
};

request(options, function(error, response, body) {
    if (error) throw new Error(error);
    console.log(body);
});
function retrieveEntity(entityId, opts) {
    return new Promise(function(resolve, reject) {
        const apiInstance = new NgsiV2.EntitiesApi();
        apiInstance.retrieveEntity(entityId, opts, (error, data) => {
            return error ? reject(error) : resolve(data);
        });
    });
}
function displayDevice(req, res) {
    retrieveEntity(req.params.deviceId, { options : "KeyValues" , type: "Device" })
        .then(device => {
            return res.render("store", { title: device.name, device });
        })
        .catch(error => {
            debug(error);
            return res.render("device-error", { title: "Error", error });
        });
}


function updateExistingEntityAttributes(entityId, body, opts) {
    return new Promise(function(resolve, reject) {
        const apiInstance = new NgsiV2.EntitiesApi();
        apiInstance.updateExistingEntityAttributes(entityId, body, opts, (error, data) => {
            return error ? reject(error) : resolve(data);
        });
    });
}