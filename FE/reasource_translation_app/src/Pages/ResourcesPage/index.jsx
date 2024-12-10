import {Button, Col, Container, Form, FormControl, Row, Table} from "react-bootstrap";
import React from "react";

function ResourcesPage(){
    return(
        <>
            <Container>
                <Form className="mt-2">
                    <Row>
                        <Col>
                            <FormControl placeholder="name"/>
                        </Col>
                        <Col>
                            <FormControl placeholder="code"/>
                        </Col>
                        <Col>
                            <Button type="submit">Add</Button>
                        </Col>
                    </Row>
                </Form>
                <Table striped className="mt-2">
                    <thead>
                    <td>Name</td>
                    <td>AppKey</td>
                    <td>Actions</td>
                    </thead>
                    <tr>
                        <td>
                            Yes
                        </td>
                        <td>
                            YES
                        </td>
                        <td className="p-1" colSpan={2}>
                            <Button variant="primary">Edit</Button>
                        </td>
                        <td>
                            <Button variant="danger">Delete</Button>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            No
                        </td>
                        <td>
                            NO
                        </td>
                        <td colSpan={2}>
                            <Button variant="primary">Edit</Button>
                        </td>
                        <td>
                            <Button variant="danger">Delete</Button>
                        </td>
                    </tr>
                </Table>
            </Container>
        </>
    )
}

export default ResourcesPage;