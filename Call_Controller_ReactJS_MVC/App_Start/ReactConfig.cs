using JavaScriptEngineSwitcher.Core;
using JavaScriptEngineSwitcher.V8;

namespace Call_Controller_ReactJS_MVC
{
	public static class ReactConfig
	{
		public static void Configure()
		{
			JsEngineSwitcher.Current.DefaultEngineName = V8JsEngine.EngineName;
			JsEngineSwitcher.Current.EngineFactories.AddV8();
		}
	}
}