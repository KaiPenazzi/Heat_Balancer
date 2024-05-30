'use client'

import useSWR from 'swr'
import Button from './(components)/Button'
import { useFilePicker } from 'use-file-picker';

const fetcher = (...args) => fetch(...args).then((res) => res.json())

function Remove(id) {
    console.log(id);
    fetch('http://localhost:5169/heater/remove?ID=' + id, {
        method:'post'
    }); 

}

function StartSimulation(time){
    fetch('http://localhost:5169/sim/start?Time=' + time,{
        method: 'post'
    })
}

function Add(heater){
    fetch('http://localhost:5169/heater/add?Heater=')
}



export default function Home() {

    function filePicker(id){
        const { openFilePicker, filesContent } = useFilePicker({
            accept: '.dm',
            onFilesSuccessfullySelected: ({ filesContent}) => {
                // this callback is called when there were no validation errors
                fetch('http://localhost:5169/data/add',{
                    method:'post',
                    headers: {
                        "Content-Type": "application/json",
                        // 'Content-Type': 'application/x-www-form-urlencoded',
                      },
                    body: JSON.stringify({
                        ID: id,
                        Data: filesContent[0].content
                    })
                })
              },
        });
        return (<Button onClick={() => {openFilePicker();}}>AddDemand</Button>);
    }

    
    
    const { data: heaters = [], error } = useSWR('http://localhost:5169/status', fetcher, { refreshInterval: 400 })


    //console.log(JSON.stringify(heaters));

    if (error) console.log(error)

    //return (<main></main>);

    return (
        <main className="flex flex-col items-center p-24">
            <Button onClick={() => StartSimulation(200)}>Start Simulation</Button>
            <table className="table-auto">
                <thead>
                    <tr>
                        <th className="">Name</th>
                        <th>Demand</th>
                        <th>Remove</th>
                        <th>Demand</th>
                    </tr>
                </thead>
                <tbody>
                    {heaters.map((heater) => {
                        return (<tr key={heater.id}>
                            <td> {heater.name} </td>
                            <td> {heater.demand} </td>
                            <td><Button onClick={() => Remove(heater.id)}>Remove</Button></td>
                            <td>{() => filePicker(heater.id)}</td>
                        </tr>)
                    })}
                </tbody>
            </table>
        </main>
    );
}
