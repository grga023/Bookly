import { useParams } from "react-router-dom"

export default function Smestaj() {
  const { id } = useParams();

  return (
    <div>{id}</div>
  )
}
