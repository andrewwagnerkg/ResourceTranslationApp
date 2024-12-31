import {Button, Col, Row, Spinner} from "react-bootstrap";

export const LoadingButton = (props)=>{
    return (
        <>
            <Button variant={props.variant} type="button" onClick = {()=>props.onClick()}>
                <Row>
                    {
                        props.isLoading && <Col>
                            <Spinner className="mt-auto-2"
                                     as="span"
                                     animation="border"
                                     size="sm"
                                     role="status"
                                     aria-hidden="true"
                            ></Spinner>
                            <span className="visually-hidden">Loading...</span>
                        </Col>
                    }
                    <Col>
                        {props.text}
                    </Col>
                </Row>
            </Button>
        </>
    )
}