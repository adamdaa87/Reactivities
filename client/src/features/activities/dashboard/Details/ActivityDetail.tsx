import { Button, Card, CardContent, CardMedia, Typography } from "@mui/material"

type Props = {
    activity: Activity
    cancelSelectActivity: () => void
    openForm: (id?: string) => void

}

export default function ActivityDetail({activity, cancelSelectActivity, openForm}: Props) {
  return (
    <Card sx= {{borderRdius: 3}}>
        <CardMedia 
            component='img' 
            src={`/assets/categoryImages/${activity.category}.jpg`}/>
        <CardContent>
            <Typography variant="h5">{activity.title}</Typography>
            <Typography variant="subtitle1" fontWeight='light'>{activity.date}</Typography>
            <Typography variant="body1">{activity.description}</Typography>   
        </CardContent>
        <Button onClick={()=> openForm(activity.id)} color = "primary">Edit</Button>
        <Button onClick={cancelSelectActivity} color = "inherit">Cancel</Button>    
    </Card>
  )
}
