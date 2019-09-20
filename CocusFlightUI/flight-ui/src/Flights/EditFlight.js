import React from 'react';
import { Container, Col, Form, Row, FormGroup, Label, Input, Button } from 'reactstrap';
import axios from 'axios'
import '../Flights/AddFlight.css'
class EditFlight extends React.Component {
    constructor(props) {
        super(props)

        this.onChangeDestination = this.onChangeDestination.bind(this);
        this.onChangeDeparture = this.onChangeDeparture.bind(this);
        this.onSubmit = this.onSubmit.bind(this);

        this.state = {
            destination: '',
            departure: '',
            airports: []
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

        axios.get('https://localhost:44356/api/airports')
            .then(response => {
                this.setState({ airports: response.data.entities });
            })
            .catch(function (error) {
                console.log(error);
            });
    }

    onChangeDestination(e) {
        let airport = this.state.airports.find(function(el) { return el.id == e.target.value});
        this.setState({
            destination: airport
        });
    }

    onChangeDeparture(e) {
        let airport = this.state.airports.find(function(el) { return el.id == e.target.value});
        this.setState({
            departure: airport
        });
    }

    onSubmit(e) {
        console.log("here");
        e.preventDefault();
        const obj = {
            id:this.props.match.params.id,
            destination: this.state.destination,
            departure: this.state.departure
        };
        axios.put('https://localhost:44356/api/flights/'+this.props.match.params.id, obj)
            .then(res => console.log(res.data));
        this.props.history.push('/Flights')
    }
    render() {
        let airports = this.state.airports;
        let departureItems = airports.map((airport) =>
            <option key={airport.id} value={airport.id}>{airport.name}</option>
        );
        let destinationItems = airports.map((airport) =>
            <option key={airport.id} value={airport.id}>{airport.name}</option>
        );
        return (
            <Container className="App">
                <h4 className="PageHeading">Enter Flight Informations</h4>
                <Form className="form" onSubmit={this.onSubmit}>
                    <Col>
                        <FormGroup row>
                            <Label for="departure" sm={2}>Departure</Label>
                            <Col sm={10}>
                                <div>
                                    <select name="departure" value={this.state.departure.id} onChange={this.onChangeDeparture.bind(this)}>
                                        {departureItems}
                                    </select>
                                </div>
                            </Col>
                        </FormGroup>
                        <FormGroup row>
                            <Label for="destination" sm={2}>Destination</Label>
                            <Col sm={10}>
                                <div>
                                    <select name="destination" value={this.state.destination.id} onChange={this.onChangeDestination.bind(this)}>
                                        {destinationItems}
                                    </select>
                                </div>
                            </Col>
                        </FormGroup>
                    </Col>
                    <Col>
                        <FormGroup row>
                            <Col sm={5}></Col>
                            <Col sm={1}>
                                <button type="submit" className="btn btn-success">Submit</button>
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

export default EditFlight;