import logo from './logo.svg';


import { Fragment, useEffect, useState  } from "react";
import axios from 'axios';
import useForm from "react-router-dom";
import {Link,useHistory} from "react-router-dom";
import { Container, Row , Modal , ModalBody, ModalHeader, Button, Col ,Table, Label} from "reactstrap"

const ModalExample = (props) => {
const baseURL="https://localhost:44348/cursos/";
  const [data,setData]=useState([]);
  const [datas,setDatas]=useState([]);
  const [opcionSeleccionado,setOpcionSeleccionado]=useState({
    nombre: "",
   descripcion: "",
    cui :""

  })

  const peticionPost=async()=>{    
      
    console.log(opcionSeleccionado)
    await axios.post(baseURL+"addUCursos",opcionSeleccionado)
    
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
  await axios.post(baseURL+"deleteCursos",opcionSeleccionado)
    
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
<Label>Curso</Label>
  <input type="text" id="nom" name="nombre" className="form-control"  onChange={handleChange}   />
  <Label>Descripcion</Label>
<input type="text" id="des" name="descripcion" className="form-control" onChange={handleChange}  />

<Button onClick={()=>peticionPost()} >Agregar</Button>
  <hr></hr>


<table className="table table-bordered">
<thead>
  <th>Curso</th>
  <th>Descripcion</th>
  <th> codigo</th>

  
</thead>
<tbody>
{
data.map(curso=>(
<tr key={curso.codigo}>
  <td>{curso.nombre}</td>
  <td>{curso.descripcion}</td>
  <td>{curso.codigo}</td>



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