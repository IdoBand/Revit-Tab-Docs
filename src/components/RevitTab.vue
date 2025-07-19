<script setup lang="ts">

import RevitPanel from './RevitPanel.vue'
import RevitTabButton from './RevitLargeButton.vue'
import RevitSmallButton from './RevitSmallButton.vue'
import RevitDropdownButton from './RevitDropdownButton.vue'
import { useTheme } from '../composables/useTheme'

type TabProps = {
  tabName: string
}
defineProps<TabProps>()

const { toggleTheme, isDark } = useTheme()
</script>

<template>
  <div class="revit-tab-container">
    <div class="pas">
      <div class="revit-tab-name">
        {{ tabName }}
      </div>
      <button class="theme-toggle" @click="toggleTheme">
        <svg v-if="isDark" width="16" height="16" viewBox="0 0 24 24" fill="none" xmlns="http://www.w3.org/2000/svg">
          <circle cx="12" cy="12" r="5" stroke="orange" stroke-width="2"/>
          <path d="M12 1v2m0 18v2M4.22 4.22l1.42 1.42m12.72 12.72l1.42 1.42M1 12h2m18 0h2M4.22 19.78l1.42-1.42m12.72-12.72l1.42-1.42" stroke="orange" stroke-width="2"/>
        </svg>
        <svg v-else width="16" height="16" viewBox="0 0 24 24" fill="none" xmlns="http://www.w3.org/2000/svg">
          <path d="M21 12.79A9 9 0 1 1 11.21 3 7 7 0 0 0 21 12.79z" stroke="currentColor" stroke-width="2"/>
        </svg>
      </button>
    </div>
    <div class="revit-tab">
      <slot>
        <!-- Model Management Panel -->
        <RevitPanel title="Model Management" width="180px">
          <RevitTabButton label="Wall Cleanup" imageSrc="/revitIcons/wall-cleanup.svg" />
          <RevitTabButton label="Model Validator" imageSrc="/revitIcons/model-checker.svg" />
          <RevitTabButton label="Quality Assurance" imageSrc="/revitIcons/quality-assurance.svg" />
        </RevitPanel>
        
        <!-- Documentation Panel -->
        <RevitPanel title="Documentation" width="160px">
          <RevitTabButton label="Room Tagging" imageSrc="/revitIcons/room-tagging.svg" />
          <RevitTabButton label="Sheet Creation" imageSrc="/revitIcons/sheet-creation.svg" />
          <RevitTabButton label="Detail Components" imageSrc="/revitIcons/detail-components.svg" />
        </RevitPanel>
        
        <!-- Standards Panel -->
        <RevitPanel title="Standards" width="180px">
          <RevitTabButton label="View Templates" imageSrc="/revitIcons/view-templates.svg" />
          <RevitTabButton label="Dimension Styles" imageSrc="/revitIcons/dimension-styles.svg" />
          <RevitTabButton label="Text Standardization" imageSrc="/revitIcons/text-standardization.svg" />
        </RevitPanel>
        
        <!-- Data Management Panel -->
        <RevitPanel title="Data Management" width="180px">
          <RevitTabButton label="Schedule Export" imageSrc="/revitIcons/schedule-export.svg" />
          <RevitTabButton label="Parameter Manager" imageSrc="/revitIcons/parameter-manager.svg" />
          <RevitTabButton label="Family Manager" imageSrc="/revitIcons/family-manager.svg" />
        </RevitPanel>
        
        <!-- Coordination Panel -->
        <RevitPanel title="Coordination" width="160px">
          <RevitTabButton label="Link Management" imageSrc="/revitIcons/link-management.svg" />
          <RevitTabButton label="Coordination Review" imageSrc="/revitIcons/coordination-review.svg" />
        </RevitPanel>
        
        <!-- Automation Panel -->
        <RevitPanel title="Automation" width="140px">
          <RevitTabButton label="Batch Processing" imageSrc="/revitIcons/batch-processing.svg" />
        </RevitPanel>
        
        <!-- Utilities Panel -->
        <RevitPanel title="Utilities" width="160px">
          <RevitTabButton label="Element Purge" imageSrc="/revitIcons/element-purge.svg" />
          <RevitTabButton label="Workset Manager" imageSrc="/revitIcons/workset-manager.svg" />
          <RevitTabButton label="Clash Detection" imageSrc="/revitIcons/clash-detection.svg" />
        </RevitPanel>
        
        <!-- Pin Tools Panel -->
        <RevitPanel title="Pin Tools" width="120px">
          <RevitDropdownButton imageSrc="/revitIcons/pin-dropdown.svg" label="Pin Tools">
            <RevitSmallButton label="Pin Manual" imageSrc="/revitIcons/pin-manual.svg" />
            <RevitSmallButton label="Pin Selection" imageSrc="/revitIcons/pin-selection.svg" />
            <RevitSmallButton label="Pin Automatic" imageSrc="/revitIcons/pin-automatic.svg" />
          </RevitDropdownButton>
        </RevitPanel>
      </slot>
    </div>
  </div>
</template>

<style scoped>
.revit-tab-container {
  width: 100%;
  background: #d0d0d0;
  border-bottom: 1px solid #a0a0a0;
}
.pas {
  display: flex;
  width: auto;
  justify-content: space-between;
  align-items: center;
}
.revit-tab-name {
  background: #2e5a8a;
  color: white;
  font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
  font-size: 12px;
  font-weight: 400;
  padding: 6px 8px 4px 8px;
  text-align: left;
  border: none;
  border-top: 3px solid #4a90e2;
  position: relative;
  display: flex;
  align-items: center;
  justify-content: space-between;
  min-width: 60px;
  max-width: max-content;
}

.theme-toggle {
  background: none;
  border: none;
  cursor: pointer;
  font-size: 14px;
  padding: 2px 4px;
  border-radius: 3px;
  transition: background-color 0.2s;
}

.theme-toggle:hover {
  background: rgba(255, 255, 255, 0.1);
}

.revit-tab {
  display: flex;
  flex-wrap: wrap;
  width: 100%;
  min-height: 100px;
  background: linear-gradient(to bottom, #f8f8f8 0%, #e8e8e8 50%, #d8d8d8 100%);
  border-bottom: 2px solid #a0a0a0;
  box-shadow: 
    inset 0 1px 0 rgba(255, 255, 255, 0.4),
    0 2px 4px rgba(0, 0, 0, 0.1);
  position: relative;
}

.revit-tab::before {
  content: '';
  position: absolute;
  top: 0;
  left: 0;
  right: 0;
  height: 1px;
  background: rgba(255, 255, 255, 0.6);
}

.revit-tab::after {
  content: '';
  position: absolute;
  bottom: 0;
  left: 0;
  right: 0;
  height: 1px;
  background: rgba(0, 0, 0, 0.2);
}
</style>