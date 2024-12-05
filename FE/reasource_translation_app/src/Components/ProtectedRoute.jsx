import {Navigate} from "react-router";

export const ProtectedRoute = (props) => {
        if(props.auth){
            return props.children;
        }
        else{
            return <Navigate to={"/login"} replace/>;
        }
}