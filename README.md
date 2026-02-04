# Interaction System - [Onur İnal]

> Ludu Arts Unity Developer Intern Case

## Proje Bilgileri

| Bilgi | Değer |
|-------|-------|
| Unity Versiyonu | 6000.0.23f1 |
| Render Pipeline | Built-in / URP / HDRP |
| Case Süresi | 12 saat |
| Tamamlanma Oranı | %50 |

---

## Kurulum

1. Repository'yi klonlayın:
```bash
git clone https://github.com/onurinal/BasicTouch.git
```

2. Unity Hub'da projeyi açın
3. `Assets/BasicTouch/Scenes/Gameplay.unity` sahnesini açın
4. Play tuşuna basın

---

## Nasıl Test Edilir

### Kontroller

| Tuş | Aksiyon |
|-----|---------|
| WASD | Hareket |
| Mouse | Bakış yönü |
| E | Etkileşim |

### Test Senaryoları

1. **Door Test:**
   - Kapıya yaklaşın, "Press to open door" mesajını görün
   - E'ye basın, kapı açılsın
   - Tekrar basın, kapı kapansın

2. **Key + Locked Door Test:**
   - Kilitli kapıya yaklaşın, "Locked - Key Required" mesajını görün
   - Anahtarı bulun ve toplayın
   - Kilitli kapıya geri dönün, şimdi açılabilir olmalı

---

## Mimari Kararlar

### Interaction System Yapısı

```
[Mimari diyagram veya açıklama]
```

**Neden bu yapıyı seçtim:**
> Interface yapısını kullanarak mimariyi oluşturdum. Bu yapıyı kullanmamın sebebi daha modular, daha scalable olması. İleride herhangi bir interactable obje eklenmesi gerektiğinde IInteractable interface türlerinden bir tanesini kalıtım alarak basit bir şekilde interactable olduğunu belirtmiş oluyoruz. Böylece player etkileşime girdiğinde bunun hangi class olduğunu bilmesine gerek kalmadan bu objenin etkileşime girebilen bir obje olduğunu bilmesi yeterli oluyor.

**Alternatifler:**
> Interface mimarisi dışında aklıma şimdilik abstract base class geldi. Abstract ile interaction bir base class oluşturup ardından door, key gibi itemler bu abstract class'ı kalıtım alıp interactable item olduklarını anlayabiliriz. Interface kullanarak interaction mimarisi yapmak çok daha kolay olduğunu düşündüğümden bunu kullanmadım.

**Trade-off'lar:**
> Projeyi yaparken zamanım kalmadığı için trade off' un açıkçası ne olduğunu bilmiyordum. README kısmını güncelledikten sonra ne olduğunu öğreneceğim.

### Kullanılan Design Patterns

| Pattern | Kullanım Yeri | Neden |
|---------|---------------|-------|
| [Observer] | [Event system] | [Basit bir EventManager sistemi kullandım, scriptler arası bağımlılıkları azaltmak için.]
| [State - Enum Based] | [Door states] | [State pattern basit hali. Bir Enum ile Locked/Unlocked state ekledim. Bool değişkeni yeterli olsa da ileride başka stateler eklenmesi gerektiğinde Enum ile daha rahat kontrol edebiliriz. ]
| [Singleton] | [UI Manager] | [Case süresi az kaldığından singleton'a başvurmak zorunda kaldım. Daha hızlı ve daha kolay erişebilmek adına yoksa elimden geldiğince kullanmamaya çalışırım.]

## Ludu Arts Standartlarına Uyum

### C# Coding Conventions

| Kural | Uygulandı | Notlar |
|-------|-----------|--------|
| m_ prefix (private fields) | [x] / [ ] | |
| s_ prefix (private static) | [x] / [ ] | |
| k_ prefix (private const) | [x] / [ ] | |
| Region kullanımı | [x] / [ ] | |
| Region sırası doğru | [x] / [ ] | |
| XML documentation | [x] / [ ] | |
| Silent bypass yok | [x] / [ ] | |
| Explicit interface impl. | [] / [x] | |

### Naming Convention

| Kural | Uygulandı | Örnekler |
|-------|-----------|----------|
| P_ prefix (Prefab) | [x] / [ ] | P_LockedDoor1, P_Player |
| M_ prefix (Material) | [x] / [ ] | M_Ground, M_LockedDoor1 |
| T_ prefix (Texture) | [] / [x] | Texture kullanılmadı. |
| SO isimlendirme | [] / [x] | Daha fazla sürem kalmadığından SO isimlendirmesine bakamadım. |

### Prefab Kuralları

| Kural | Uygulandı | Notlar |
|-------|-----------|--------|
| Transform (0,0,0) | [x] / [ ] | |
| Pivot bottom-center | [x] / [ ] | |
| Collider tercihi | [x] / [ ] | Genellikle box collider kullanıldı fakat anahtar ve interaction range için sphere collider kullandım. Sürem yetmediğinden buralarda düzenlemeye gidemedim. |
| Hierarchy yapısı | [x] / [ ] | |

### Zorlandığım Noktalar
> [Standartları uygularken zorlandığınız yerler]

açıkçası ilk başta dökümanları okurken baya zaman kaybettim diyebilirim. Ardından daha fazla zaman kaybetmemek adına aklıam gelen en basit yapıları eklemeye çalışırken door interaction sistemini ekledikten sonra ve anahtar ekleme kısmına gelince neredeyse zamanımın kalmadığını anladım. 

## Tamamlanan Özellikler

### Zorunlu (Must Have)

- [x] / [ ] Core Interaction System
  - [x] / [ ] IInteractable interface
  - [x] / [ ] InteractionDetector
  - [x] / [ ] Range kontrolü

- [x] / [ ] Interaction Types
  - [x] / [ ] Instant
  - [x] / [ ] Hold
  - [x] / [ ] Toggle

- [x] / [ ] Interactable Objects
  - [x] / [ ] Door (locked/unlocked)
  - [x] / [ ] Key Pickup
  - [] / [x] Switch/Lever
  - [] / [x] Chest/Container

- [x] / [ ] UI Feedback
  - [x] / [ ] Interaction prompt
  - [x] / [ ] Dynamic text
  - [] / [x] Hold progress bar
  - [] / [x] Cannot interact feedback

- [x] / [ ] Simple Inventory
  - [x] / [ ] Key toplama
  - [] / [x] UI listesi

### Bonus (Nice to Have)

- [ ] Animation entegrasyonu
- [ ] Sound effects
- [ ] Multiple keys / color-coded
- [ ] Interaction highlight
- [ ] Save/Load states
- [ ] Chained interactions

---

## Bilinen Limitasyonlar

### Tamamlanamayan Özellikler
1. [Özellik] - [Neden tamamlanamadı]
2. [Özellik] - [Neden]

### Bilinen Bug'lar
1. [Bug açıklaması] - [Reproduce adımları]
2. [Bug]

### İyileştirme Önerileri
1. [Öneri] - [Nasıl daha iyi olabilirdi]
2. [Öneri]

---

## Ekstra Özellikler

Zorunlu gereksinimlerin dışında eklediklerim:

1. **[Özellik Adı]**
   - Açıklama: [Ne yapıyor]
   - Neden ekledim: [Motivasyon]

2. **[Özellik Adı]**
   - ...

---

## Dosya Yapısı

```
Assets/
├── [ProjectName]/
│   ├── Scripts/
│   │   ├── Runtime/
│   │   │   ├── Core/
│   │   │   │   ├── IInteractable.cs
│   │   │   │   └── ...
│   │   │   ├── Interactables/
│   │   │   │   ├── Door.cs
│   │   │   │   └── ...
│   │   │   ├── Player/
│   │   │   │   └── ...
│   │   │   └── UI/
│   │   │       └── ...
│   │   └── Editor/
│   ├── ScriptableObjects/
│   ├── Prefabs/
│   ├── Materials/
│   └── Scenes/
│       └── TestScene.unity
├── Docs/
│   ├── CSharp_Coding_Conventions.md
│   ├── Naming_Convention_Kilavuzu.md
│   └── Prefab_Asset_Kurallari.md
├── README.md
├── PROMPTS.md
└── .gitignore
```

---

## İletişim

| Bilgi | Değer |
|-------|-------|
| Ad Soyad | [Adınız] |
| E-posta | [email@example.com] |
| LinkedIn | [profil linki] |
| GitHub | [github.com/username] |

---

*Bu proje Ludu Arts Unity Developer Intern Case için hazırlanmıştır.*
