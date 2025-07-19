<script setup lang="ts">
import Tabs from 'primevue/tabs';
import TabList from 'primevue/tablist';
import Tab from 'primevue/tab';
import TabPanels from 'primevue/tabpanels';
import TabPanel from 'primevue/tabpanel';
import { selectedButton } from '../composables/useSelectedButton';

</script>

<template>

    <Tabs value="0" class="tabs">
      <TabList>
        <nav class="tabs-list-nav">
          <div>
            <Tab value="0">Overview</Tab>
            <Tab value="1">Technical Info</Tab>
            <Tab value="2">Known Bugs</Tab>
          </div>
          <span> {{ selectedButton?.label }}</span>
        </nav>
      </TabList>
      <TabPanels>
        <TabPanel value="0" class="panel">
          <p>
            {{ selectedButton.docs ?? "" }}
          </p>
        </TabPanel>
        <TabPanel value="1" class="panel">
          <p>
            {{ selectedButton.technicalInfo ?? "" }}
          </p>
        </TabPanel>
        <TabPanel value="2" class="panel">
          <p style="white-space: pre-wrap;">
            {{ selectedButton.bugs ? selectedButton?.bugs : "Yay! No bugs!"}}
          </p>
        </TabPanel>
      </TabPanels>
    </Tabs>

  </template>

<style scoped>

.tabs {
  margin: 2rem auto 0 auto;
  border: 1px solid var(--border-bg);
  width: 60vw;
}
.panel {
  height: calc(100vh - 400px);
}

.tabs-list-nav {
  display: flex;
  align-items: center;
  justify-content: space-between;
  width: 100%;

  border-radius: var(--br);
}
.tabs-list-nav > span {
  padding-right: 1em;
  border-radius: var(--br);
}
.tab {
  border-radius: var(--br);
}
.p-tabpanels {
  min-height: calc(100vh - 300px);
}

</style>
