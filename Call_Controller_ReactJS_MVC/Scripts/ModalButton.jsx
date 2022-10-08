const { Button, Header, Image, Modal, Label, Input } = semanticUIReact
function ModalButton() {
    const [open, setOpen] = React.useState(false);
    const [name, setName] = React.useState("");
    const [address, setAddress] = React.useState("");

    return (
        <Modal
            onClose={() => setOpen(false)}
            onOpen={() => setOpen(true)}
            open={open}
            trigger={<Button>New Customer</Button>}
        >
            <Modal.Header>Create Customer</Modal.Header>
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
                    content="Create"
                    labelPosition='right'
                    icon='checkmark'
                    onClick={() => setOpen(false)}
                    positive
                />
            </Modal.Actions>
        </Modal>
    )
}

//export default ModalButton
