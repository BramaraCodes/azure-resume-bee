window.addEventListener('DOMContentLoaded', (event) =>{
    getVisitCount();
})

const functionApiUrl = 'https://azgetresumecounters.azurewebsites.net/api/GetResumeCounter?code=ztzxM9QcZM0gIc5ckgOgUipjl__D0MBSPy2qpk6iTkofAzFu95L6Eg==';
const localfunctionApi = 'http://localhost:7071/api/GetResumeCounter';

const getVisitCount = () =>{
    let count = 30;
    fetch(functionApiUrl).then(response =>{
        return response.json() // get the data and returns to json
    }).then(response =>{
        console.log("Website called function API.");
        count = response.count;
        document.getElementById("counter").innerText = count;
    }).catch(function(error){
        console.log(error);
    });
    return count;
}