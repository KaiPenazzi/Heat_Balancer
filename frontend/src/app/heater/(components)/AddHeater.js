import Button from './Button'

function Add(name, ip) {
    fetch('http://localhost:5169/heater/add', {
        method: 'post',
        headers: {
            "Content-Type": "application/json",
        },
        body: JSON.stringify({
            Name: name.value,
            IP: ip.value,
        })

    }).then(response => {
        if (response.status != 200) {
            alert("can't connect to the server");
        }
    })

    name.value = "";
    ip.value = "";
}

export default function AddHeater() {
    return (
        <div className="flex flex-col items-center">
            <label>Name:</label>
            <input id='name' className="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"></input>
            <label>IP:</label>
            <input id='ip' className="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"></input>

            <Button onClick={() => Add(document.getElementById('name'), document.getElementById('ip'))}>Add Heater</Button>
        </div>
    )
}
