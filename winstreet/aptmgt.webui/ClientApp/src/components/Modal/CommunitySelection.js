import Modal from 'react-modal';

var CommunityModal = React.createClass({
    render() {
        return (
            <Modal
                isOpen={this.props.isOpen}
                className="modal-content"
                contentLabel="modal"
                onRequestClose={this.props.onClose} >
                <h1 className="modal-header">{this.props.title}</h1>
                <div className="modal-body">
                    <p>{this.props.message}</p>
                </div>

                <Button bsStyle={this.props.type} className="modal-button" onClick={this.props.closeModal}>Close</Button>

            </Modal>
        )
    }
});

const mapStateToProps = (state) => {
    return {
        isOpen: state.modals.notification.isOpen,
        type: state.modals.notification.type,
        title: state.modals.notification.title,
        message: state.modals.notification.message,
    }
};

const mapDispatchToProps = (dispatch) => {
    return {
        closeModal: () => dispatch(skjeraActionCreators.closeNotificationModal()),
    }
};

export default CommunityModal;