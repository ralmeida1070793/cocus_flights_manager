import React, { Component } from 'react';
import axios from 'axios';
import { Link } from 'react-router-dom';
class Table extends Component {
    constructor(props) {
        super(props);
    }

    DeleteAeroplane= () =>{
        axios.delete('https://localhost:44356/api/aeroplanes/'+this.props.obj.id)
            .then(res => {
                window.location.reload()
            })
    }
    render() {
        return (
            <tr>
                <td>
                    {this.props.obj.name}
                </td>
                <td>
                    {this.props.obj.capacity}
                </td>
                <td>
                    {this.props.obj.takeoffEffortPerOccupiedSeat}
                </td>
                <td>
                    {this.props.obj.fuelConsumptionPerSeat}
                </td>
                <td>
                    <Link to={"/edit/"+this.props.obj.id} className="btn btn-success">Edit</Link>
                </td>
                <td>
                    <button type="button" onClick={this.DeleteAeroplane} className="btn btn-danger">Delete</button>
                </td>
            </tr>
        );
    }
}

export default Table;