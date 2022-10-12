class ReactAJAX extends React.Component {
    constructor(props) {
        super(props);
        this.state = { Name: "", serviceList: [] };

        this.updateName = this.updateName.bind(this);
        this.handleClick = this.handleClick.bind(this);
        this.loadData = this.loadData.bind(this);
        this.update = this.update.bind(this);
        this.delete = this.delete.bind(this);
    }
    updateName(e) {
        this.setState({ Name: e.target.value });
    }
    componentDidMount() {
        this.loadData();
        console.log("inside load 1");
    }

    update(id) {
        //ajax call logic
    }

    delete(id) {
        //ajax call logic
    }


    loadData() {
        var request;
        if (window.XMLHttpRequest) {
            //New browsers.
            request = new XMLHttpRequest();
        }
        else if (window.ActiveXObject) {
            //Old IE Browsers.
            request = new ActiveXObject("Microsoft.XMLHTTP");
        }
        
        if (request != null) {

            request.open("GET", "/Customer/Index", false);
            //var params = "{name: '" + this.state.Name + "'}";
            request.setRequestHeader("Content-Type", "application/json");
            request.onload = function () {
                if (request.readyState == 4 && request.status == 200) {
                    console.log(request.responseText);
                    const obj = JSON.parse(request.responseText);
                    console.log(obj);
                    this.setState({ serviceList: obj });
                    //alert("Hello: " + response.Name + " .\nCurrent Date and Time: " + response.DateTime);
                }
            }.bind(this);
            request.send();
        }
    }


    handleClick() {
        var request;
        if (window.XMLHttpRequest) {
            //New browsers.
            request = new XMLHttpRequest();
        }
        else if (window.ActiveXObject) {
            //Old IE Browsers.
            request = new ActiveXObject("Microsoft.XMLHTTP");
        }
        if (request != null) {
            
            request.open("POST", "/Home/AjaxMethod", false);
            var params = "{name: '" + this.state.Name + "'}";
            request.setRequestHeader("Content-Type", "application/json");
            request.onload = function () {
                if (request.readyState == 4 && request.status == 200) {
                    var response = JSON.parse(request.responseText);
                    console.log(response);
                    alert("Hello: " + response.Name + " .\nCurrent Date and Time: " + response.DateTime);
                }
            }.bind(this);
            request.send(params);
        }

        if (request != null) {

            request.open("GET", "/Customer/Index", false);
            //var params = "{name: '" + this.state.Name + "'}";
            request.setRequestHeader("Content-Type", "application/json");
            request.onload = function () {
                if (request.readyState == 4 && request.status == 200) {
                    console.log(request.responseText);
                    //alert("Hello: " + response.Name + " .\nCurrent Date and Time: " + response.DateTime);
                }
            }.bind(this);
            request.send();
        }
    }
   
    render() {
        let serviceList = this.state.serviceList;
        console.log("inside load 3");
        let tableData = null;

        if (serviceList != "") {
            tableData = serviceList.map(service =>
                <tr key={service.ID}>
                    <td className="two wide" key={service.ID}>{service.Name}</td>
                    <td className="ten wide" key={service.ID}>{service.Address}</td>
                    <td className="four wide" key={service.ID}>
                        <i className="outline write icon" onClick={this.update.bind(this, service.id)}></i>
                        <i className="remove icon" onClick={this.delete.bind(this, service.id)}></i>
                        <EditModalButton custId={service.ID}/>
                    </td>
                    <td className="four wide" key={service.ID}>
                        <DeleteModalButton custId={service.ID} />
                    </td>
                </tr>
            )
        }

        return (
            <React.Fragment>
                <ModalButton />
                <table className="ui striped table">
                    <thead>
                        <tr>
                            <th className="two wide">Name</th>
                            <th className="ten wide">Address</th>
                            <th className="four wide">Actions</th>
                            <th className="four wide">Actions</th>
                        </tr>
                    </thead>
                    <tbody>
                        {tableData}
                    </tbody>
                </table>
            </React.Fragment>

        );
    }
}

ReactDOM.render(
    <ReactAJAX />,
    document.getElementById('dvMessage')
); 