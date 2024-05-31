import { useFilePicker } from 'use-file-picker'
import Button from './Button'

export default function AddDemand({ id }) {

    const { openFilePicker, fileContent } = useFilePicker({
        accept: '.dm',

        onFilesSuccessfullySelected: ({ filesContent }) => {
            fetch('http://localhost:5169/data/add', {
                method: 'post',
                headers: {
                    "Content-Type": "application/json",
                },
                body: JSON.stringify({
                    ID: id,
                    Data: filesContent[0].content
                })
            })
        }
    })

    return (
        <Button onClick={() => openFilePicker()}> AddDemand </Button>
    )
}
