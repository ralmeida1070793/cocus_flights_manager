import React from 'react';
import axios from 'axios';
import '../Airports/AddAirport.css'
import { Container, Col, Form, Row, FormGroup, Label, Input, Button } from 'reactstrap';
class AddAirport extends React.Component{
    constructor(props){
        super(props)
        this.state = {
            name: '',
            latitude: '',
            longitude: ''

        }
    }
    AddAirport=()=>{
        axios.post('https://localhost:44356/api/airports',
            {
                name:this.state.name,
                latitude:this.state.latitude,
                longitude:this.state.longitude
            })
            .then(res => {
                if(res.status === 200){
                    alert("Data Save Successfully");
                    this.props.history.push('/Airports')
                }
                else{
                    alert('Data not Saved');
                    this.props.history.push('/Airports')
                }
            })
    }

    handleChange= (e)=> {
        this.setState({[e.target.name]:e.target.value});
    }

    render() {
        return (
            <Container className="App">
                <h4 className="PageHeading">Enter Airport Informations</h4>
                <Form className="form">
                    <Col>
                        <FormGroup row>
                            <Label for="name" sm={2}>Name</Label>
                            <Col sm={10}>
                                <Input type="text" name="name" onChange={this.handleChange} value={this.state.name} placeholder="Enter Name" />
                            </Col>
                        </FormGroup>
                        <FormGroup row>
                            <Label for="latitude" sm={2}>Latitude</Label>
                            <Col sm={10}>
                                <Input type="text" name="latitude" onChange={this.handleChange} value={this.state.latitude} placeholder="Enter Latitude" />
                            </Col>
                        </FormGroup>
                        <FormGroup row>
                            <Label for="longitude" sm={2}>Longitude</Label>
                            <Col sm={10}>
                                <Input type="text" name="longitude" onChange={this.handleChange} value={this.state.longitude} placeholder="Enter Longitude" />
                            </Col>
                        </FormGroup>
                    </Col>
                    <Col>
                        <FormGroup row>
                            <Col sm={5}></Col>
                            <Col sm={1}>
                                <button type="button" onClick={this.AddAirport} className="btn btn-success">Submit</button>
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

export default AddAirport;