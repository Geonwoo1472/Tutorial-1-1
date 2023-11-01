<div align="center">
<h2>[2023] 2D 탑다운 어드벤처 퍼즐 게임 제작 🎮</h2>
각 맵의 퍼즐을 클리어하여 챕터를 통과해 나가는 방식의 게임 JonIsland입니다!<br>
플레이어가 탈진하지 않게끔😇 아이템을 활용해 퍼즐을 끝까지 풀어보세요!

</div>

## 목차
  - [개요](#개요) 
  - [게임 설명](#게임-설명)
  - [게임 플레이 방식](#게임-플레이-방식)

## 개요
- 프로젝트 이름: JOHN ISLAND 🏝️
- 프로젝트 지속기간: 2023.05-2023.10
- 개발 엔진 및 언어: Unity , C#
- 멤버: 팀 명철호(남건우, 윤현승, 조하연, 박기덕)

## 게임 설명
|![Untitled](https://github.com/Geonwoo1472/Tutorial-1-1/assets/110521729/932602c5-800b-4027-bf00-4f7078261d01)|![Untitled (1)](https://github.com/Geonwoo1472/Tutorial-1-1/assets/110521729/c4e143c2-a5e1-4d6e-9565-c3fc70b2cf2d)|
|:---:|:---:|
|시작 화면|불러오기 화면|

복합적으로 구성되어 퍼즐을 풀어내 성취감과 즐거움을 줄 수 있는 게임을 만들고자 (JonsIsland)를 개발하게 되었습니다.
- 생존 (Survival)🆘<br>
무인도에 표류되어 있습니다! 배고파지고 피로해집니다.. 먹을 것을 찾아 움직여야 합니다!<br>
나아가는 길이 순탄치 않습니다! 물체와 상호작용시 마다 피로도가 소모됩니다. 여러군데 배치되어 있는 음식을 통해 회복할 수 있습니다.
이 과정은 여러가지의 수단을 고려해 앞으로 나아가야합니다.

- 탐험 (Exploration)🔎<br>
이 섬을 탈출해야합니다! 나갈 단서와 수단을 찾아내기 위해 힘이 닿는 곳 까지 여러군데를 탐험해봅시다!<br>
이 게임은 5가지의 스테이지로 구성되어 있습니다. 각 스테이지마다 테마와 사운드 요구하는 퍼즐의 방식이 달라 하나의 게임에서 여러 재미를 향유할 수 있습니다.

- 위험 대처 (Danger Management)😨<br>
활동할 수록 힘이 빠집니다. 효율적으로 움직여야 합니다!!
퍼즐을 올바르게 풀어야합니다만, 캐릭터의 활동에는 제약이 있습니다. 생존하기 위해서는 최단경로로 움직이거나 퍼즐을 효율적으로 풀어내야합니다!

- 휴식 (Rest) ❤️‍🩹<br>
효율적인 활동을 위해 숙면을 취해야 합니다. 다행이도 섬 어딘가에는 텐트가 있는 것 같습니다!<br>
퍼즐을 풀어 앞으로 나아가면 플레이하는 유저도 휴식이 필요할 수 있습니다. JONSISLAND는 저장기능을 제공하며 저장했던 부분에서 다시 시작해 퍼즐을 풀어나가봅시다!

## 게임 플레이 방식
- 게임 조작 방법

|이동방향|상(위)|좌(왼쪽)|하(아래)|우(오른쪽)|지도|상호작용|인벤토리|화면 닫기|
|---|---|---|---|---|---|---|---|---|
|키보드|⬆️(W)|⬅️(A)|⬇️(S)|➡️(D)|M|Space bar|I|ESC|

- Stage 소개

|![Untitled (11)](https://github.com/Geonwoo1472/Tutorial-1-1/assets/110521729/48cde6e1-342d-4f3e-a34f-b4aaca1b8dc2)|![Untitled (12)](https://github.com/Geonwoo1472/Tutorial-1-1/assets/110521729/2a9127a9-faf4-4614-be97-2d1bcd3f9996)|
|:---:|:---:|
|1Stage|2Stage|
|해변 테마|숲 테마|

|![Untitled (13)](https://github.com/Geonwoo1472/Tutorial-1-1/assets/110521729/91f6a45b-e89c-41b3-9dad-13ff7d0d9159)|![Untitled (14)](https://github.com/Geonwoo1472/Tutorial-1-1/assets/110521729/aec58ff2-93d0-4cff-b02c-4360ef4fce6c)|
|:---:|:---:|
|3Stage|4Stage|
|동굴 테마|유적 테마|

|![Untitled (15)](https://github.com/Geonwoo1472/Tutorial-1-1/assets/110521729/2f57b130-6715-45b5-a9e4-918f421febdf)|![Untitled (16)](https://github.com/Geonwoo1472/Tutorial-1-1/assets/110521729/7ebb4681-2afb-4279-b2a8-aa27bf2eb5bf)|
|:---:|:---:|
|5Stage Send|5Stage Sea|
|섬 외곽 테마|섬 바다 테마|

|![Untitled (17)](https://github.com/Geonwoo1472/Tutorial-1-1/assets/110521729/ea45ee1a-d4e2-4afd-8520-b159a7ac31dc)|
|:---:|
|각 스테이지 별 저장 공간<br> 1->2 , 2->3<br> 3->4, 4->5|

- 기능 설명

|플레이어|이동|상호작용|피로도|배고픔|맵과 스테이지|맵 이동|맵 이동|인벤토리|
|:---:|:---:|:---:|:---:|:---:|:---:|:---:|:---:|:---:|
|![image01](https://github.com/Geonwoo1472/Tutorial-1-1/assets/110521729/674fdb86-127f-4619-8e7e-2ed0d260dabc)|![image02](https://github.com/Geonwoo1472/Tutorial-1-1/assets/110521729/d719abee-263b-49f1-8671-91e793164497)|![image03](https://github.com/Geonwoo1472/Tutorial-1-1/assets/110521729/dd8a7e45-18f7-4953-a4dc-ec13edf32e15)|![image04](https://github.com/Geonwoo1472/Tutorial-1-1/assets/110521729/6310f9df-0bf2-479f-a8df-fc37f63387c8)|![image05](https://github.com/Geonwoo1472/Tutorial-1-1/assets/110521729/2e04536b-a4e7-4608-a938-03dee425c538)|![image06](https://github.com/Geonwoo1472/Tutorial-1-1/assets/110521729/c03ca605-5411-41aa-9a39-b20889fec0cc)|![image07](https://github.com/Geonwoo1472/Tutorial-1-1/assets/110521729/0d7354cf-fd29-4a86-8967-a5210355229f)|![image08](https://github.com/Geonwoo1472/Tutorial-1-1/assets/110521729/bb828600-ba43-4bb3-9e2f-668e43c56ea6)|![image09](https://github.com/Geonwoo1472/Tutorial-1-1/assets/110521729/a5655b59-6e20-4b93-bcb3-d7ea8a4ffb14)|
|게임을 진행하는 플레이어|이동키를 눌렀을 때 모습|상호작용 중 [스위치]|오브젝트와 상호작용 시 감소|맵을 넘어가는 경우 감소|큰 범주는 스테이지 작은 범주는 맵|맵간 이동 포탈|특수한 맵으로 이동하는 포탈|아이템이 저장되는 공간|

- 상호작용 가능한 오브젝트들

|텐트|팻말|부식된 나무|이어진 동굴|가시 발판|늪|스위치|
|:---:|:---:|:---:|:---:|:---:|:---:|:---:|
|![image24](https://github.com/Geonwoo1472/Tutorial-1-1/assets/110521729/891c1d9e-f80f-44ed-bc49-67c19f2667a7)|![image23](https://github.com/Geonwoo1472/Tutorial-1-1/assets/110521729/18f5658c-a60f-4a92-8ac3-fa960b5b37fe)|![image22](https://github.com/Geonwoo1472/Tutorial-1-1/assets/110521729/fb9d2dd7-64e6-43e2-9f9a-e4f9de113fad)|![image21](https://github.com/Geonwoo1472/Tutorial-1-1/assets/110521729/f4084933-39df-4152-982b-958fe6174771)|![image20](https://github.com/Geonwoo1472/Tutorial-1-1/assets/110521729/50d902d4-6c16-449c-a0d6-be404dbf15f4)|![image19](https://github.com/Geonwoo1472/Tutorial-1-1/assets/110521729/66b14124-96a3-4ace-894f-8b1950e91782)|![image18](https://github.com/Geonwoo1472/Tutorial-1-1/assets/110521729/c9ac8a40-fafa-4b06-93a1-56ce5b910eed)|
|저장 가능|상호작용으로 단서 획득|상호작용으로 피로도를 소모하여 제거 가능|1회용 입구|타임어택에 배치된 정지 트랩|스테미너 1감소|중요 오브젝트 활성화|

|플레이어가 밀 수 있는 오브젝트|
|:---:|
|![image17](https://github.com/Geonwoo1472/Tutorial-1-1/assets/110521729/cb61654c-8e22-4d20-8e1f-d575aa888142)![image16](https://github.com/Geonwoo1472/Tutorial-1-1/assets/110521729/1a11a1e1-c60d-4a49-945f-77cd1b11251a)![image15](https://github.com/Geonwoo1472/Tutorial-1-1/assets/110521729/fa3ab922-a923-41b0-8aa7-2dd72db04ad0)![image14](https://github.com/Geonwoo1472/Tutorial-1-1/assets/110521729/3cba2802-ea18-4446-b21f-9cb910434b85)|
|플레이어가 미는 방향으로 오브젝트가 이동|

- 아이템

|지도|횃불|열쇠|음식|과일|버섯|
|:---:|:---:|:---:|:---:|:---:|:---:|
|![image25](https://github.com/Geonwoo1472/Tutorial-1-1/assets/110521729/d14f25b7-8d66-4246-98de-8fc4aecaee61)|![image13](https://github.com/Geonwoo1472/Tutorial-1-1/assets/110521729/0d1f780c-9e8a-4d8d-9a9f-11e925bb0b85)|![image12](https://github.com/Geonwoo1472/Tutorial-1-1/assets/110521729/6de10035-1f0e-4b76-a427-8967b375faaa)|![image11](https://github.com/Geonwoo1472/Tutorial-1-1/assets/110521729/b871ac8d-295a-4fea-878c-80e172bb1415)|![image10](https://github.com/Geonwoo1472/Tutorial-1-1/assets/110521729/3e2afa5e-d63b-465f-a40e-41d6fe52e24d)|![image09](https://github.com/Geonwoo1472/Tutorial-1-1/assets/110521729/3187c9a0-d368-4a52-8230-042dd7dbc72d)|![image08](https://github.com/Geonwoo1472/Tutorial-1-1/assets/110521729/e16a4cf1-451f-4841-a964-158250763e98)|
|숨겨진 공간을 알려줌|제한된 시야를 밝힘|다음 스테이지로 넘어가기 위한 아이템|피로도를 회복|피로도가 회복되거나 감소|피로도가 회복되거나 감소|


- 조절 기능

|![Untitled (2)](https://github.com/Geonwoo1472/Tutorial-1-1/assets/110521729/dd7cf1cc-af4d-43fe-ac80-3b8be740b1f0)|![Untitled (3)](https://github.com/Geonwoo1472/Tutorial-1-1/assets/110521729/7a2f67db-7036-4cb0-982a-3543c3279c44)|
|:---:|:---:|
|조작키 변경|음향 조절|

- 스토리

|![Untitled (4)](https://github.com/Geonwoo1472/Tutorial-1-1/assets/110521729/240df410-2fd3-46bc-ae58-946f0f286a05)|![Untitled (5)](https://github.com/Geonwoo1472/Tutorial-1-1/assets/110521729/cc028f5c-b445-4b22-b63b-8d4442a9f303)|![Untitled (6)](https://github.com/Geonwoo1472/Tutorial-1-1/assets/110521729/235cef20-715b-4657-ba15-6a37c66f73e6)|
|:---:|:---:|:---:|
|인트로 화면|굿 엔딩 화면|베드 엔딩 화면|




|인게임 화면|
|:---:|
|![Untitled (7)](https://github.com/Geonwoo1472/Tutorial-1-1/assets/110521729/4522aa5e-85af-47c1-89f6-d8f0a36d6db3)|
