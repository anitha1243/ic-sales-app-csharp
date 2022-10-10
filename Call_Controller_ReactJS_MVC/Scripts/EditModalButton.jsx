//const { Header, Image, Modal, Label, Input } = semanticUIReact
function EditModalButton(props) {
    const [open, setOpen] = React.useState(false);
    const [name, setName] = React.useState("");
    const [address, setAddress] = React.useState("");

    function saveRecord() {
        setOpen(false)
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

            request.open("POST", "/Customer/EditCustomer", false);
            var params = "{ID: " + props.custId + ", Name: '" + name + "', Address: '" + address + "'}";
            console.log(params);
            request.setRequestHeader("Content-Type", "application/json");
            request.onload = function () {
                if (request.readyState == 4 && request.status == 200) {
                    var response = JSON.parse(request.responseText);
                    console.log(response);
                }
            }.bind(this);
            request.send(params);
        }
    }

    return (
        <Modal
            onClose={() => setOpen(false)}
            onOpen={() => setOpen(true)}
            open={open}
            trigger={<Button>Edit Customer</Button>}
        >
            <Modal.Header>Edit Customer</Modal.Header>
            <Modal.Content image>
                
                <Modal.Description>
                    <div>
                        <Label>NAME</Label>
                        <Input onChange={event => setName(event.target.value)} />
                    </div>
                    <div>
                        <Label>ADDRESS</Label>
                        <Input onChange={event => setAddress(event.target.value)} />
                    </div>                   
                    
                </Modal.Description>
            </Modal.Content>
            <Modal.Actions>
                <Button color='black' onClick={() => setOpen(false)}>
                    Cancel
                </Button>
                <Button
                    content="Edit"
                    labelPosition='right'
                    icon='checkmark'
                    onClick={saveRecord}
                    positive
                />
            </Modal.Actions>
        </Modal>
    )
}

//export default EditModalButton
