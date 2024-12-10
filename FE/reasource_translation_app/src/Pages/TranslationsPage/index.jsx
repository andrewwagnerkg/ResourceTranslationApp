import {Button, Col, Container, Form, FormControl, Row, Table} from "react-bootstrap";
import React from "react";

function TranslationsPage() {
    return  (
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
                    <td>Resource</td>
                    <td>Locale</td>
                    <td>Translation</td>
                    <td>Actions</td>
                    </thead>
                    <tr>
                        <td>
                            Yes/YES
                        </td>
                        <td>
                            ru-RU
                        </td>
                        <td>
                            Да
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
                            No/NO
                        </td>
                        <td>
                            ru-RU
                        </td>
                        <td>
                            Нет
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
                            Yes/YES
                        </td>
                        <td>
                            ky-KG
                        </td>
                        <td>
                            Ооба
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
                            No/NO
                        </td>
                        <td>
                            ky-KG
                        </td>
                        <td>
                            Жок
                        </td>
                        <td className="p-1" colSpan={2}>
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

export default TranslationsPage;