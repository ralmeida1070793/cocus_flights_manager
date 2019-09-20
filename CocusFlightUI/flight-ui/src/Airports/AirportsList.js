import React, { Component } from 'react';
import axios from 'axios';
import Table from './Table';

export default class AirportsList extends Component {

    constructor(props) {
        super(props);
        this.state = {business: []};
    }
    componentDidMount() {
        axios.get('https://localhost:44356/api/airports')
            .then(response => {
                this.setState({ business: response.data.entities });
            })
            .catch(function (error) {
                console.log(error);
            })
    }

    tabRow(){
        return this.state.business.map(function(object, i){
            return <Table obj={object} key={i} />;
        });
    }

    render() {
        return (
            <div>
                <h4 align="center">Airport List</h4>
                <table className="table table-striped" style={{ marginTop: 10 }}>
                    <thead>
                        <tr>
                            <th>Name</th>
                            <th>Latitude</th>
                            <th>Longitude</th>
                            <th colSpan="4"></th>
                        </tr>
                    </thead>
                    <tbody>
                        { this.tabRow() }
                    </tbody>
                </table>
            </div>
        );
    }
}