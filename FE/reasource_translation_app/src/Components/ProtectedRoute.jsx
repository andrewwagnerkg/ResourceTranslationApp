import {Navigate} from "react-router";
import {useAuthProvider} from "../Hooks/UseAuthProvider.js";

export const ProtectedRoute = (props) => {
    const {checkAuth} = useAuthProvider();
        if(checkAuth()){
            return props.children;
        }
        else{
            return <Navigate to={"/login"} replace/>;
        }
}