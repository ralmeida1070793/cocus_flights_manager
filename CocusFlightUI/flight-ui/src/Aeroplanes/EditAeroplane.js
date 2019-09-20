import React from 'react';
import { Container, Col, Form, Row, FormGroup, Label, Input, Button } from 'reactstrap';
import axios from 'axios'
import '../Aeroplanes/AddAeroplane.css'
class EditAeroplane extends React.Component {
    constructor(props) {
        super(props)

        this.onChangeName = this.onChangeName.bind(this);
        this.onChangeCapacity = this.onChangeCapacity.bind(this);
        this.onChangeTakeoffEffortPerOccupiedSeat = this.onChangeTakeoffEffortPerOccupiedSeat.bind(this);
        this.onChangeFuelConsumptionPerSeat = this.onChangeFuelConsumptionPerSeat.bind(this);
        this.onSubmit = this.onSubmit.bind(this);

        this.state = {
            name: '',
            capacity: '',
            takeoffEffortPerOccupiedSeat: '',
            fuelConsumptionPerSeat: ''

        }
    }

    componentDidMount() {
        axios.get('https://localhost:44356/api/aeroplanes/'+this.props.match.params.id)
            .then(response => {
                this.setState({
                    name: response.data.name,
                    capacity: response.data.capacity,
                    takeoffEffortPerOccupiedSeat: response.data.takeoffEffortPerOccupiedSeat,
                    fuelConsumptionPerSeat: response.data.fuelConsumptionPerSeat });

            })
            .catch(function (error) {
                console.log(error);
            })
    }

    onChangeName(e) {
        this.setState({
            name: e.target.value
        });
    }
    onChangeCapacity(e) {
        this.setState({
            capacity: e.target.value
        });
    }
    onChangeTakeoffEffortPerOccupiedSeat(e) {
        this.setState({
            takeoffEffortPerOccupiedSeat: e.target.value
        });
    }
    onChangeFuelConsumptionPerSeat(e) {
        this.setState({
            fuelConsumptionPerSeat: e.target.value
        });
    }

    onSubmit(e) {
        debugger;
        e.preventDefault();
        const obj = {
            id:this.props.match.params.id,
            name: this.state.name,
            capacity: this.state.capacity,
            takeoffEffortPerOccupiedSeat: this.state.takeoffEffortPerOccupiedSeat,
            fuelConsumptionPerSeat: this.state.fuelConsumptionPerSeat

        };
        axios.put('https://localhost:44356/api/aeroplanes/'+this.props.match.params.id, obj)
            .then(res => console.log(res.data));
        debugger;
        this.props.history.push('/AeroplaneList')
    }
    render() {
        return (
            <Container className="App">
                <h4 className="PageHeading">Update Aeroplane Informations</h4>
                <Form className="form" onSubmit={this.onSubmit}>
                    <Col>
                        <FormGroup row>
                            <Label for="name" sm={2}>Name</Label>
                            <Col sm={10}>
                                <Input type="text" name="name" value={this.state.name} onChange={this.onChangeName} placeholder="Enter Name" />
                            </Col>
                        </FormGroup>
                        <FormGroup row>
                            <Label for="Capacity" sm={2}>Capacity</Label>
                            <Col sm={10}>
                                <Input type="text" name="capacity" value={this.state.capacity} onChange={this.onChangeCapacity} placeholder="Enter Capacity" />
                            </Col>
                        </FormGroup>
                        <FormGroup row>
                            <Label for="TakeoffEffortPerOccupiedSeat" sm={2}>Takeoff Effort Per Occupied Seat</Label>
                            <Col sm={10}>
                                <Input type="text" name="takeoffEffortPerOccupiedSeat" value={this.state.takeoffEffortPerOccupiedSeat} onChange={this.onChangeTakeoffEffortPerOccupiedSeat} placeholder="Enter TakeoffEffortPerOccupiedSeat" />
                            </Col>
                        </FormGroup>
                        <FormGroup row>
                            <Label for="FuelConsumptionPerSeat" sm={2}>Fuel Consumption Per Seat</Label>
                            <Col sm={10}>
                                <Input type="text" name="fuelConsumptionPerSeat"value={this.state.fuelConsumptionPerSeat} onChange={this.onChangeFuelConsumptionPerSeat} placeholder="Enter FuelConsumptionPerSeat" />
                            </Col>
                        </FormGroup>
                    </Col>
                    <Col>
                        <FormGroup row>
                            <Col sm={5}></Col>
                            <Col sm={1}>
                                <Button type="submit" color="success">Submit</Button>{' '}
                            </Col>
                            <Col sm={1}>
                                <Button color="danger">Cancel</Button>{' '}
                            </Col>
                            <Col sm={5}></Col>
                        </FormGroup>
                    </Col>
                </Form>
            </Container>
        );
    }
}

export default EditAeroplane;