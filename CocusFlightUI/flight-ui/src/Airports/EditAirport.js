import React from 'react';
import { Container, Col, Form, Row, FormGroup, Label, Input, Button } from 'reactstrap';
import axios from 'axios'
import '../Airports/AddAirport.css'
class EditAirport extends React.Component {
    constructor(props) {
        super(props)

        this.onChangeName = this.onChangeName.bind(this);
        this.onChangeLongitude = this.onChangeLongitude.bind(this);
        this.onChangeLatitude = this.onChangeLatitude.bind(this);
        this.onSubmit = this.onSubmit.bind(this);

        this.state = {
            name: '',
            latitude: '',
            longitude: ''
        }
    }

    componentDidMount() {
        axios.get('https://localhost:44356/api/airports/'+this.props.match.params.id)
            .then(response => {
                this.setState({
                    name: response.data.name,
                    latitude: response.data.latitude,
                    longitude: response.data.longitude });

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
    onChangeLatitude(e) {
        this.setState({
            latitude: e.target.value
        });
    }
    onChangeLongitude(e) {
        this.setState({
            longitude: e.target.value
        });
    }

    onSubmit(e) {
        e.preventDefault();
        const obj = {
            id:this.props.match.params.id,
            name: this.state.name,
            latitude: this.state.latitude,
            longitude: this.state.longitude
        };
        axios.put('https://localhost:44356/api/airports/'+this.props.match.params.id, obj)
            .then(res => console.log(res.data));
        this.props.history.push('/Airports')
    }
    render() {
        return (
            <Container className="App">
                <h4 className="PageHeading">Update Airport Informations</h4>
                <Form className="form" onSubmit={this.onSubmit}>
                    <Col>
                        <FormGroup row>
                            <Label for="name" sm={2}>Name</Label>
                            <Col sm={10}>
                                <Input type="text" name="name" value={this.state.name} onChange={this.onChangeName.bind(this)} placeholder="Enter Name" />
                            </Col>
                        </FormGroup>
                        <FormGroup row>
                            <Label for="latitude" sm={2}>Latitude</Label>
                            <Col sm={10}>
                                <Input type="text" name="latitude" value={this.state.latitude} onChange={this.onChangeLatitude.bind(this)} placeholder="Enter Latitude" />
                            </Col>
                        </FormGroup>
                        <FormGroup row>
                            <Label for="longitude" sm={2}>Longitude</Label>
                            <Col sm={10}>
                                <Input type="text" name="longitude" value={this.state.longitude} onChange={this.onChangeLongitude.bind(this)} placeholder="Enter Longitude" />
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

export default EditAirport;