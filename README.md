# Flight Logging System
The new Flight Logging System (short called FLS) repository for .NET core server and Angular frontend.

The FLS manages glider and motor flights of clubs from the reservation until exporting to the invoicing system. The main features of the system are:
* Maintaining base data like:
  * Clubs (Tenant)
  * Users
  * Aircrafts
  * Persons with relations to the club(s)
  * Club-related flight types
  * Locations
  * Club-related accounting rules
  * Club-related member states and person categories
* Edit and validate glider- and motor flights
* Aircraft reservations
* Planning of flight days with flight instructor, tow-pilot and flight operator
* System- and club-related email template handling
* Workflow engine for several automated processes like email notification, invoice exports, etc.

## Additional extensions to the FLS
### Proffix Sync Interface
The Proffix Sync Interface synchronizes addresses, flights, deliveries and articles between Proffix and FLS Server. It automates the invoicing process of flights in Proffix. For more information see also: https://github.com/arminstutz/PROFFIX-FLS-Sync

### FLS OGN Analyser
The OGN Analyser analyses flight GPS data from Open Glider Net and creates starts and landing events for FLS. See also: https://github.com/flightlog/FLSOgnAnalyser

## Versioning

We use [SemVer](http://semver.org/) for versioning.

## License

This project is licensed under the [GNU General Public License v3.0](https://github.com/flightlog/flightloggingsystem/blob/main/LICENSE).
