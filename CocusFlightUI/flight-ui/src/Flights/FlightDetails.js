import React from 'react';
import { Container, Col, Form, Row, FormGroup, Label, Input, Button } from 'reactstrap';
import axios from 'axios'
import '../Flights/AddFlight.css'
class FlightDetails extends React.Component {
    constructor(props) {
        super(props)

        this.state = {
            destination: '',
            departure: '',
            cost: '',
            aeroplane: '',
            aeroplanes: []
        }
    }

    componentDidMount() {
        axios.get('https://localhost:44356/api/flights/'+this.props.match.params.id)
            .then(response => {
                this.setState({
                    departure: response.data.departure,
                    destination: response.data.destination
                });
            })
            .catch(function (error) {
                console.log(error);
            });

        axios.get('https://localhost:44356/api/aeroplanes')
            .then(response => {
                this.setState({ aeroplanes: response.data.entities });
            })
            .catch(function (error) {
                console.log(error);
            });
    }

    onChangeAeroplane(e) {
        this.setState({aeroplane: e.target.value});
        axios.get( 'https://localhost:44356/api/flights/' + this.props.match.params.id + '/plane/' + e.target.value )
            .then(response => {
                this.setState({
                    cost: response.data.consumption
                });
            })
            .catch(function (error) {
                console.log(error);
            });
    }

    render() {
        let aeroplanes = this.state.aeroplanes;
        let aeroplanesItems = aeroplanes.map((aeroplane) =>
            <option key={aeroplane.id} value={aeroplane.id}>{aeroplane.name}</option>
        );

        return (
            <Container className="App">
                <h4 className="PageHeading">Calculate Consumption for Flight</h4>
                <Form className="form" onSubmit="return false;">
                    <Col>
                        <FormGroup row>
                            <Label sm={2}>Departure</Label>
                            <Col sm={10}>
                                <div>
                                    {this.state.departure.name}
                                </div>
                            </Col>
                        </FormGroup>
                        <FormGroup row>
                            <Label sm={2}>Destination</Label>
                            <Col sm={10}>
                                <div>
                                    <div>
                                        {this.state.destination.name}
                                    </div>
                                </div>
                            </Col>
                        </FormGroup>
                        <FormGroup row>
                            <Label sm={2}>Aeroplane</Label>
                            <Col sm={10}>
                                <div>
                                    <select name="aeroplanes" value={this.state.aeroplane} onChange={this.onChangeAeroplane.bind(this)}>
                                        <option key="0" value="0"></option>
                                        {aeroplanesItems}
                                    </select>
                                </div>
                            </Col>
                        </FormGroup>
                        <FormGroup row>
                            <Label sm={2}>Flight Consumption</Label>
                            <Col sm={10}>
                                <div>
                                    <div>
                                        {this.state.cost}
                                    </div>
                                </div>
                            </Col>
                        </FormGroup>
                    </Col>
                </Form>
            </Container>
        );
    }
}

export default FlightDetails;