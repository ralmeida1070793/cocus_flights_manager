import React from 'react';
import axios from 'axios';
import '../Aeroplanes/AddAeroplane.css'
import { Container, Col, Form, Row, FormGroup, Label, Input, Button } from 'reactstrap';
class AddAeroplane extends React.Component{
    constructor(props){
        super(props)
        this.state = {
            name: '',
            capacity: '',
            takeoffEffortPerOccupiedSeat: '',
            fuelConsumptionPerSeat: ''

        }
    }
    AddAeroplane=()=>{
        axios.post('https://localhost:44356/api/aeroplanes',
            {
                name:this.state.name,
                capacity:this.state.capacity,
                takeoffEffortPerOccupiedSeat:this.state.takeoffEffortPerOccupiedSeat,
                fuelConsumptionPerSeat:this.state.fuelConsumptionPerSeat
            })
            .then(res => {
                if(res.status === 200){
                    alert("Data Save Successfully");
                    this.props.history.push('/AeroplanesList')
                }
                else{
                    alert('Data not Saved');
                    debugger;
                    this.props.history.push('/AeroplanesList')
                }
            })
    }

    handleChange= (e)=> {
        this.setState({[e.target.name]:e.target.value});
    }

    render() {
        return (
            <Container className="App">
                <h4 className="PageHeading">Enter Aeroplane Informations</h4>
                <Form className="form">
                    <Col>
                        <FormGroup row>
                            <Label for="name" sm={2}>Name</Label>
                            <Col sm={10}>
                                <Input type="text" name="name" onChange={this.handleChange} value={this.state.name} placeholder="Enter Name" />
                            </Col>
                        </FormGroup>
                        <FormGroup row>
                            <Label for="capacity" sm={2}>Capacity</Label>
                            <Col sm={10}>
                                <Input type="text" name="capacity" onChange={this.handleChange} value={this.state.capacity} placeholder="Enter Capacity" />
                            </Col>
                        </FormGroup>
                        <FormGroup row>
                            <Label for="takeoffEffortPerOccupiedSeat" sm={2}>Takeoff Effort Per Occupied Seat</Label>
                            <Col sm={10}>
                                <Input type="text" name="takeoffEffortPerOccupiedSeat" onChange={this.handleChange} value={this.state.takeoffEffortPerOccupiedSeat} placeholder="Enter Takeoff Effort Per Occupied Seat" />
                            </Col>
                        </FormGroup>
                        <FormGroup row>
                            <Label for="fuelConsumptionPerSeat" sm={2}>FuelConsumptionPerSeat</Label>
                            <Col sm={10}>
                                <Input type="text" name="fuelConsumptionPerSeat" onChange={this.handleChange} value={this.state.fuelConsumptionPerSeat} placeholder="Enter Fuel Consumption Per Seat" />
                            </Col>
                        </FormGroup>
                    </Col>
                    <Col>
                        <FormGroup row>
                            <Col sm={5}></Col>
                            <Col sm={1}>
                                <button type="button" onClick={this.AddAeroplane} className="btn btn-success">Submit</button>
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

export default AddAeroplane;