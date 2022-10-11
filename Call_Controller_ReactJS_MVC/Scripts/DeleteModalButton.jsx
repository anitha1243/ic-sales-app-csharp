//const { Header, Image, Modal, Label, Input } = semanticUIReact
function DeleteModalButton(props) {
    const [open, setOpen] = React.useState(false);

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

            request.open("POST", "/Customer/DeleteCustomer", false);
            var params = "{ID: " + props.custId + "}";
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
            trigger={<Button>Delete Customer</Button>}
        >
            <Modal.Header>Delete Customer</Modal.Header>
            <Modal.Content image>
                
                <Modal.Description>
                    Are you sure you want to delete this customer?                 
                    
                </Modal.Description>
            </Modal.Content>
            <Modal.Actions>
                <Button color='black' onClick={() => setOpen(false)}>
                    Cancel
                </Button>
                <Button
                    content="Delete"
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
