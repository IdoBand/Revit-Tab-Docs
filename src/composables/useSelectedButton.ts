import jsonData from '../assets/revit-tools-documentation.json'
import { ref } from 'vue'
import type { RevitButtonProps } from '../assets/types'


const placeHolderButton: RevitButtonProps = {
    label: "",
    docs: "Click on either of the buttons!",
    bugs: "",
    technicalInfo: "",
    imageSrc: ""
}

export const selectedButton = ref<RevitButtonProps>(placeHolderButton)

export function setSelectedButton(buttonLabel: string): void {
    try {
        const foundItem = (jsonData as RevitButtonProps[]).find(item => 
            item.label === buttonLabel
        )
        
        selectedButton.value = foundItem!

        console.log(foundItem)
    } catch (error) {
        selectedButton.value = placeHolderButton
    }
}