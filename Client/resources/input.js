function getProjects() {
    const allPostsApiUrl = "https://localhost:5001/API/Project"

    fetch(allPostsApiUrl).then(function(response){
        console.log(response);
        return response.json();
    }).then(function(json){
        let html = "<table class=\"center\"><tr><th>Project ID</th><th>Project Name</th><th>Project Status</th><th>Delete</th></tr>";
        json.forEach((project)=>{
            var id = project.projectID;
            html += "<tr><td>" + project.projectID + "</td><td>" + "<a href=\"./breakoutview.html\" target=\"_blank\">" + project.projectName + "</a>" + "</td><td>" + project.currentStatus + "</td><td><button onclick=\"newDelete(" + project.projectID + ")\">X</button></tr>";
        })
        html += "</table>"
        document.getElementById("project").innerHTML = html;
    }).catch(function(error){
        console.log(error);
    })
}

function addProject() {
    const postsApiUrl = "https://localhost:5001/API/Project"
    const name = document.getElementById("posttext").value;
    const deliveryDate = document.getElementById("deliverydate").value;
    const manager = document.getElementById("managername").value;
    const client = document.getElementById("clientname").value;

    var paymentInfo = "error";
    var paymentMethod = document.getElementsByName('payment');

    var statusInfo = "error";
    var status = document.getElementsByName('status');

    for (var i = 0, length = paymentMethod.length; i < length; i++) {
        if (paymentMethod[i].checked) {
            paymentInfo = paymentMethod[i].value;

            break;
        }
    }

    for (var i = 0, length = status.length; i < length; i++) {
        if (status[i].checked) {
            statusInfo = status[i].value;

            break;
        }
    }

    const payChoice = paymentInfo;
    const statusChoice = statusInfo;
    
    fetch(postsApiUrl, {
        method: "POST",
        headers: {
            "Accept": 'application/json',
            "Content-Type": 'application/json'
        },
        body: JSON.stringify({
            projectName: name,
            deliveryDate: deliveryDate,
            paymentMethod: payChoice,
            currentStatus: statusChoice,
            managerName: manager,
            clientName: client
        })
    }).then((response)=>{
        console.log(response);
        getProjects();
    })
}

function deleteProject() {
    const deleteApiUrl = "https://localhost:5001/API/Project"
    const id = document.getElementById("delete").value;

    fetch(deleteApiUrl + '/' + id, {
        method: "DELETE",
    }).then((response)=>{
        console.log(response);
        getProjects();
    })
}

function editProject() {
    const editUrl = "https://localhost:5001/API/Project"
    var statusInfo = "error";

    var status = document.getElementsByName('status');
    const eId = document.getElementById("editid").value

    for (var i = 0, length = status.length; i < length; i++) {
        if (status[i].checked) {
            statusInfo = status[i].value;

            break;
        }
    }

    fetch(editUrl + '/' + eId, {
        method: "PUT",
        body: JSON.stringify({
            projectID: eId,
            currentStatus: statusInfo
        }),
        headers: {
            "Content-Type": "application/json"
        }
    }).then((response)=>{
        console.log(response);
        getProjects();
    })
}

function addPage() {
    var opened = window.open("C:\\Users\\dhugh\\Documents\\MIS321\\GroupProjectCCS\\Client\\resources\\addpage.html");
}

function allInfo() {
        const allPostsApiUrl = "https://localhost:5001/API/Project"
    
        fetch(allPostsApiUrl).then(function(response){
            console.log(response);
            return response.json();
        }).then(function(json){
            let html = "<table class=\"center\"><tr><th>Project ID</th><th>Project Name</th><th>Project Status</th><th>Start Date</th><th>Delivery Date</th><th>Payment Method</th><th>Manager Name</th><th>Client Name</th></tr>";
            json.forEach((project)=>{
                html += "<tr><td>" + project.projectID + "</td><td>" + project.projectName + "</td><td>" + project.currentStatus + "</td><td>" + project.startDate + "</td><td>" + project.deliveryDate + "</td><td>" + project.paymentMethod + "</td><td>" + project.managerName + "</td><td>" + project.clientName + "</td></tr>";
            })
            html += "</table>"
            document.getElementById("info").innerHTML = html;
        }).catch(function(error){
            console.log(error);
        })
}

function allInfoPage() {
    var opened = window.open("C:\\Users\\dhugh\\Documents\\MIS321\\GroupProjectCCS\\Client\\resources\\allprojects.html");
}

function newDelete(id) {
    const deleteApiUrl = "https://localhost:5001/API/Project"
    const projectid = id;

    fetch(deleteApiUrl + '/' + projectid, {
        method: "DELETE",
    }).then((response)=>{
        console.log(response);
        getProjects();
    })
}

function breakoutView(id) {
    const breakoutUrl = "https://localhost:5001/API/Project"
    const projectid = id;


}

function sortStatus() {
    const statusUrl = "https://localhost:5001/API/Project"
    var statusInfo = "error"
    var status = document.getElementsByName('sortstatus')

    fetch(statusUrl).then(function(response){
        console.log(response);
        return response.json();
    }).then(function(json){
        let html = "<table class=\"center\"><tr><th>Project ID</th><th>Project Name</th><th>Project Status</th><th>Start Date</th><th>Delivery Date</th><th>Payment Method</th><th>Manager Name</th><th>Client Name</th></tr>";
        json.forEach((project)=>{
            project.filter()
            html += "<tr><td>" + project.projectID + "</td><td>" + project.projectName + "</td><td>" + project.currentStatus + "</td><td>" + project.startDate + "</td><td>" + project.deliveryDate + "</td><td>" + project.paymentMethod + "</td><td>" + project.managerName + "</td><td>" + project.clientName + "</td></tr>";
        })
        html += "</table>"
        document.getElementById("info").innerHTML = html;
    }).catch(function(error){
        console.log(error);
    })
    
}



