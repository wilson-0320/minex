import logo from './logo.svg';


import { Fragment, useEffect, useState  } from "react";
import axios from 'axios';
import useForm from "react-router-dom";
import {Link,useHistory} from "react-router-dom";
import { Container, Row , Modal , ModalBody, ModalHeader, Button, Col ,Table, Label} from "reactstrap"

const ModalExample = (props) => {
const baseURL="https://localhost:44348/usuario/";
  const [data,setData]=useState([]);
  const [datas,setDatas]=useState([]);
  const [opcionSeleccionado,setOpcionSeleccionado]=useState({
    nombre: "",
   apellido: "",
    cui :"",
    edad: ""

  })

  const peticionPost=async()=>{    
      
    console.log(opcionSeleccionado)
    await axios.post(baseURL+"addUsuario",opcionSeleccionado)
    
    .then (response=>{
      setData(response.data);
      //swal("Creado");

    
    }).catch(error =>{
      console.log(error);
    })
    }

    
const peticionEliminar=async(a)=>{    

  setOpcionSeleccionado({
    ...opcionSeleccionado,
    "cui":(a)})


console.log(opcionSeleccionado);
  await axios.post(baseURL+"deleteUsuario",opcionSeleccionado)
    
    .then (response=>{
     setData(response.data);
      //swal("Eliminado");

    
    }).catch(error =>{
      console.log(error);
    })
    peticionGet();


}




  const handleChange=e=>
  {
  
const{name, value}=e.target;
setOpcionSeleccionado({
  ...opcionSeleccionado,
  [name]: value
});

console.log(opcionSeleccionado);
  }


  const peticionGet=async()=>{
    
    await axios.get(baseURL+"lista")
    
    .then (response=>{
      setData(response.data);
   
    }).catch(error =>{
      console.log(error);
    })
    }

    const peticionLista=async()=>{
    
      await axios.get(baseURL+"lista")
      
      .then (response=>{
        setDatas(response.data);
      console.log("a");
      }).catch(error =>{
        console.log(error);
      })
      }
    
      useEffect(()=>{
        peticionGet();
   //     peticionLista();
        
        },[])


//
return (

<Fragment>
  <card>
<Label>Nombre</Label>
  <input type="text" id="nombre" name="nombre" className="form-control"  onChange={handleChange}   />
  <Label>Apellido</Label>
<input type="text" id="apellido" name="apellido" className="form-control" onChange={handleChange}  />
<Label>Edad</Label>
<input type="text" name="edad" id="edad" className="form-control"  onChange={handleChange} />
<Label>Cui</Label>
<input type="text" name="cui" id="cui" className="form-control" onChange={handleChange} />
<Button onClick={()=>peticionPost()} >Agregar</Button>
  <hr></hr>


<table className="table table-bordered">
<thead>
  <th>ID</th>
  <th>Nombre</th>
  <th> cui</th>
  <th> edad</th>
  <th> edad</th>

  
</thead>
<tbody>
{
data.map(usuario=>(
<tr key={usuario.cui}>
  <td>{usuario.nombre}</td>
  <td>{usuario.apellido}</td>
  <td>{usuario.cui}</td>
  <td>{usuario.edad}</td>


  <td><button  onClick={()=>peticionEliminar(usuario.cui)}   >Eliminar</button></td>
</tr>

))

}
</tbody>
</table>
</card>
</Fragment>
)
}

export default ModalExample;